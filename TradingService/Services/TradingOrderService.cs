using System;
using System.Globalization;
using System.Threading.Tasks;
using MongoDB.Driver;
using XchangeCrypt.Backend.DatabaseAccess.Models;
using XchangeCrypt.Backend.DatabaseAccess.Models.Enums;
using XchangeCrypt.Backend.DatabaseAccess.Models.Events;
using XchangeCrypt.Backend.DatabaseAccess.Repositories;

namespace XchangeCrypt.Backend.TradingService.Services
{
    // TODO: one instance per instrument?
    public class TradingOrderService
    {
        private readonly EventHistoryRepository _eventHistoryRepository;
        private IMongoCollection<OrderBookEntry> OrderBook { get; }
        private IMongoCollection<HiddenOrderEntry> HiddenOrders { get; }
        private IMongoCollection<OrderHistoryEntry> OrderHistory { get; }
        private IMongoCollection<TransactionHistoryEntry> TransactionHistory { get; }

        /// <summary>
        /// </summary>
        public TradingOrderService(TradingRepository tradingRepository, EventHistoryRepository eventHistoryRepository)
        {
            _eventHistoryRepository = eventHistoryRepository;
            OrderBook = tradingRepository.OrderBook();
            HiddenOrders = tradingRepository.HiddenOrders();
            OrderHistory = tradingRepository.OrderHistory();
            TransactionHistory = tradingRepository.TransactionHistory();
        }

        internal void CreateOrder(CreateOrderEventEntry createOrder)
        {
            switch (createOrder.Type)
            {
                case OrderType.Limit:
                    var limitOrder = new OrderBookEntry
                    {
                        EntryTime = createOrder.EntryTime,
                        CreatedOnVersionId = createOrder.VersionNumber,
                        User = createOrder.User,
                        AccountId = createOrder.AccountId,
                        Instrument = createOrder.Instrument,
                        Qty = createOrder.Qty,
                        Side = createOrder.Side,
                        FilledQty = 0m,
                        LimitPrice = createOrder.LimitPrice.Value,
                        // TODO from stop loss and take profit
                        //ChildrenIds
                        DurationType = createOrder.DurationType,
                        Duration = createOrder.Duration,
                    };
                    OrderBook.InsertOneAsync(limitOrder);
                    break;
                case OrderType.Stop:
                    var stopOrder = new HiddenOrderEntry
                    {
                        EntryTime = createOrder.EntryTime,
                        CreatedOnVersionId = createOrder.VersionNumber,
                        User = createOrder.User,
                        AccountId = createOrder.AccountId,
                        Instrument = createOrder.Instrument,
                        Qty = createOrder.Qty,
                        Side = createOrder.Side,
                        StopPrice = createOrder.StopPrice.Value,
                        // TODO from stop loss and take profit
                        //ChildrenIds
                        DurationType = createOrder.DurationType,
                        Duration = createOrder.Duration,
                    };
                    HiddenOrders.InsertOneAsync(stopOrder);
                    break;
                case OrderType.Market:
                    throw new ArgumentOutOfRangeException(nameof(createOrder.Type),
                        "Cannot create unmatched market order");
                default:
                    throw new ArgumentOutOfRangeException(nameof(createOrder.Type));
            }
        }

        internal void MatchOrder(MatchOrderEventEntry matchOrder)
        {
            // Old incorrect way:
            // In order to find actionOrderId, we must go a little roundabout way
//            var matchOrderRelatedCreateOrder = _eventHistoryRepository.Events<CreateOrderEventEntry>().Find(
//                Builders<CreateOrderEventEntry>.Filter.Eq(e => e.VersionNumber, matchOrder.VersionNumber)
//            ).First();
//            var actionOrderId = matchOrderRelatedCreateOrder.Id;

            var now = new DateTime();
            var actionOrder = OrderBook.Find(
                Builders<OrderBookEntry>.Filter.Eq(e => e.CreatedOnVersionId, matchOrder.VersionNumber)
            ).Single();
            var targetOrder = OrderBook.Find(
                Builders<OrderBookEntry>.Filter.Eq(e => e.CreatedOnVersionId, matchOrder.TargetOrderOnVersionNumber)
            ).Single();
            AssertMatchOrderQty(matchOrder, actionOrder, targetOrder);

            if (matchOrder.ActionOrderQtyRemaining == 0)
            {
                OrderBook.DeleteOne(
                    Builders<OrderBookEntry>.Filter.Eq(e => e.CreatedOnVersionId, matchOrder.VersionNumber)
                );
                // The entire order quantity was filled
                InsertOrderHistoryEntry(actionOrder.Qty, actionOrder, OrderStatus.Filled, now);
            }
            else
            {
                OrderBook.UpdateOne(
                    Builders<OrderBookEntry>.Filter.Eq(e => e.CreatedOnVersionId, matchOrder.VersionNumber),
                    Builders<OrderBookEntry>.Update.Set(e => e.FilledQty, matchOrder.ActionOrderQtyRemaining)
                );
            }

            if (matchOrder.TargetOrderQtyRemaining == 0)
            {
                OrderBook.DeleteOne(
                    Builders<OrderBookEntry>.Filter.Eq(e => e.CreatedOnVersionId, matchOrder.TargetOrderOnVersionNumber)
                );
                // The entire order quantity was filled
                InsertOrderHistoryEntry(targetOrder.Qty, targetOrder, OrderStatus.Filled, now);
            }
            else
            {
                OrderBook.UpdateOne(
                    Builders<OrderBookEntry>.Filter.Eq(
                        e => e.CreatedOnVersionId,
                        matchOrder.TargetOrderOnVersionNumber),
                    Builders<OrderBookEntry>.Update.Set(e => e.FilledQty, matchOrder.TargetOrderQtyRemaining)
                );
            }

            TransactionHistory.InsertOne(
                new TransactionHistoryEntry
                {
                    ExecutionTime = now,
                    User = targetOrder.User,
                    AccountId = targetOrder.AccountId,
                    Instrument = targetOrder.Instrument,
                    Side = targetOrder.Side,
                    OrderId = targetOrder.Id,
                    // The entire quantity was filled
                    FilledQty = matchOrder.Qty,
                    Price = matchOrder.Price,
                }
            );
        }

        private void AssertMatchOrderQty(
            MatchOrderEventEntry matchOrder, OrderBookEntry actionOrder, OrderBookEntry targetOrder)
        {
            var actionFilledQty = actionOrder.FilledQty + matchOrder.Qty;
            if (matchOrder.ActionOrderQtyRemaining != actionOrder.Qty - actionFilledQty)
            {
                throw new Exception(
                    $"Integrity assertion failed! {nameof(MatchOrderEventEntry)} ID {matchOrder.Id} attempted to increase {nameof(targetOrder.FilledQty)} of action order ID {actionOrder.Id} from {actionOrder.FilledQty.ToString(CultureInfo.CurrentCulture)} by {matchOrder.Qty}, but that didn't add up to event entry-asserted value of {matchOrder.ActionOrderQtyRemaining.ToString(CultureInfo.CurrentCulture)}!");
            }

            var targetFilledQty = targetOrder.FilledQty + matchOrder.Qty;
            if (matchOrder.TargetOrderQtyRemaining != targetOrder.Qty - targetFilledQty)
            {
                throw new Exception(
                    $"Integrity assertion failed! {nameof(MatchOrderEventEntry)} ID {matchOrder.Id} attempted to increase {nameof(targetOrder.FilledQty)} of target order ID {targetOrder.Id} from {targetOrder.FilledQty.ToString(CultureInfo.CurrentCulture)} by {matchOrder.Qty}, but that didn't add up to event entry-asserted value of {matchOrder.TargetOrderQtyRemaining.ToString(CultureInfo.CurrentCulture)}!");
            }
        }

        internal void CancelOrder(CancelOrderEventEntry cancelOrder)
        {
            var now = new DateTime();
            OrderBook.DeleteOne(
                Builders<OrderBookEntry>.Filter.Eq(e => e.Id, cancelOrder.CancelOrderId)
            );
            var targetOrder = OrderBook.Find(
                Builders<OrderBookEntry>.Filter.Eq(e => e.Id, cancelOrder.CancelOrderId)
            ).Single();
            InsertOrderHistoryEntry(targetOrder.FilledQty, targetOrder, OrderStatus.Cancelled, now);
        }

        private void InsertOrderHistoryEntry(
            decimal filledQty, OrderBookEntry orderToClose, OrderStatus status, DateTime now)
        {
            OrderHistory.InsertOne(
                new OrderHistoryEntry
                {
                    CreateTime = orderToClose.EntryTime,
                    CloseTime = now,
                    User = orderToClose.User,
                    AccountId = orderToClose.AccountId,
                    Instrument = orderToClose.Instrument,
                    Qty = orderToClose.Qty,
                    Side = orderToClose.Side,
                    // Closed limit order
                    Type = OrderType.Limit,
                    // The entire order quantity was filled
                    FilledQty = filledQty,
                    LimitPrice = orderToClose.LimitPrice,
                    StopPrice = null,
                    // TODO from stop loss and take profit
                    //ChildrenIds
                    DurationType = orderToClose.DurationType,
                    Duration = orderToClose.Duration,
                    Status = status,
                }
            );
        }

        internal async Task<IAsyncCursor<OrderBookEntry>> MatchSellers(decimal belowOrAt, string instrument)
        {
            return await OrderBook
                .Find(e => e.Side == OrderSide.Sell && e.LimitPrice <= belowOrAt && e.Instrument.Equals(instrument))
                // TODO: verify
                .Sort(Builders<OrderBookEntry>.Sort.Descending(e => e.LimitPrice))
                .ToCursorAsync();
        }

        internal async Task<IAsyncCursor<OrderBookEntry>> MatchBuyers(decimal aboveOrAt, string instrument)
        {
            return await OrderBook
                .Find(e => e.Side == OrderSide.Buy && e.LimitPrice >= aboveOrAt && e.Instrument.Equals(instrument))
                // TODO: verify
                .Sort(Builders<OrderBookEntry>.Sort.Ascending(e => e.LimitPrice))
                .ToCursorAsync();
        }
    }
}