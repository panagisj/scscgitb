using MongoDB.Bson.Serialization.Attributes;

namespace XchangeCrypt.Backend.DatabaseAccess.Models.Events
{
    [BsonKnownTypes(
        typeof(WalletEventEntry),
        typeof(WalletRevokeEventEntry),
        typeof(WalletWithdrawalEventEntry))]
    public abstract class WalletEventEntry : EventEntry
    {
        public string User;

        public string AccountId;

        public string CoinSymbol;

        public decimal NewBalance;
    }
}