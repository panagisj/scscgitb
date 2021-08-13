using System;
using System.Threading.Tasks;

namespace XchangeCrypt.Backend.TradingBackend.Services
{
    // TODO: one instance per instrument?
    public class StopOrderService : AbstractTradingOrderService
    {
        /// <summary>
        /// </summary>
        public StopOrderService()
        {
        }

        internal Task Buy(string user, string accountId, string instrument, decimal? quantity, decimal? stopPrice, string durationType, decimal? duration, decimal? stopLoss, decimal? takeProfit)
        {
            throw new NotImplementedException();
        }

        internal Task Sell(string user, string accountId, string instrument, decimal? quantity, decimal? stopPrice, string durationType, decimal? duration, decimal? stopLoss, decimal? takeProfit)
        {
            throw new NotImplementedException();
        }
    }
}