using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XchangeCrypt.Backend.DatabaseAccess.Models.Enums;

namespace XchangeCrypt.Backend.DatabaseAccess.Models
{
    [System.Obsolete]
    public class ActivityHistoryWalletOperationEntry
    {
        public ObjectId Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public ActivityHistoryEntryType EntryType { get; set; } = ActivityHistoryEntryType.WalletOperation;

        public DateTime EntryTime { get; set; }

        public string User { get; set; }

        public string AccountId { get; set; }

        public string CoinSymbol { get; set; }

        public string DepositType { get; set; }

        public string WithdrawalType { get; set; }

        public decimal Amount { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public CommitState CommitState { get; set; } = CommitState.Initial;
    }
}
