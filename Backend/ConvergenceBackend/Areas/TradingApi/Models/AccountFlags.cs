/*
 * TradingView REST API Specification for Brokers
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 *
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models
{
    /// <summary>
    ///
    /// </summary>
    [DataContract]
    public partial class AccountFlags : IEquatable<AccountFlags>
    {
        /// <summary>
        /// Renames Amount to Quantity in the Order Ticket
        /// </summary>
        /// <value>Renames Amount to Quantity in the Order Ticket</value>
        [DataMember(Name = "showQuantityInsteadOfAmount")]
        public bool? ShowQuantityInsteadOfAmount { get; set; }

        /// <summary>
        /// Whether you want for DOM (Depth of market) widget to be available
        /// </summary>
        /// <value>Whether you want for DOM (Depth of market) widget to be available</value>
        [DataMember(Name = "supportDOM")]
        public bool? SupportDOM { get; set; }

        /// <summary>
        /// Whether you support brackets. Deprecated. Use supportOrderBrackets and supportPositionBrackets instead.
        /// </summary>
        /// <value>Whether you support brackets. Deprecated. Use supportOrderBrackets and supportPositionBrackets instead.</value>
        [DataMember(Name = "supportBrackets")]
        public bool? SupportBrackets { get; set; }

        /// <summary>
        /// Whether you support adding (or modifying) stop loss and take profit to orders
        /// </summary>
        /// <value>Whether you support adding (or modifying) stop loss and take profit to orders</value>
        [DataMember(Name = "supportOrderBrackets")]
        public bool? SupportOrderBrackets { get; set; }

        /// <summary>
        /// Whether you support adding (or modifying) stop loss and take profit to positions
        /// </summary>
        /// <value>Whether you support adding (or modifying) stop loss and take profit to positions</value>
        [DataMember(Name = "supportPositionBrackets")]
        public bool? SupportPositionBrackets { get; set; }

        /// <summary>
        /// Whether you support closing of a position without a need for a user to fill an order. If it is &#x60;true&#x60; the Trading Terminal shows a confirmation dialog and sends a DELETE request instead of bringing up an order ticket.
        /// </summary>
        /// <value>Whether you support closing of a position without a need for a user to fill an order. If it is &#x60;true&#x60; the Trading Terminal shows a confirmation dialog and sends a DELETE request instead of bringing up an order ticket.</value>
        [DataMember(Name = "supportClosePosition")]
        public bool? SupportClosePosition { get; set; }

        /// <summary>
        /// Whether you support editing orders quantity. If you set it to &#x60;false&#x60;, the quantity control in the order ticket will be disabled when modifing an order.
        /// </summary>
        /// <value>Whether you support editing orders quantity. If you set it to &#x60;false&#x60;, the quantity control in the order ticket will be disabled when modifing an order.</value>
        [DataMember(Name = "supportEditAmount")]
        public bool? SupportEditAmount { get; set; }

        /// <summary>
        /// Whether you support Level 2 data. It is required to display DOM levels. You must implement &#x60;/streaming&#x60; to display DOM.
        /// </summary>
        /// <value>Whether you support Level 2 data. It is required to display DOM levels. You must implement &#x60;/streaming&#x60; to display DOM.</value>
        [DataMember(Name = "supportLevel2Data")]
        public bool? SupportLevel2Data { get; set; }

        /// <summary>
        /// Whether you support multiple positions at one instrument at the same time
        /// </summary>
        /// <value>Whether you support multiple positions at one instrument at the same time</value>
        [DataMember(Name = "supportMultiposition")]
        public bool? SupportMultiposition { get; set; }

        /// <summary>
        /// Whether you provide &#x60;unrealizedPl&#x60; for positions. Otherwise P&amp;L will be calculated automatically based on a simple algorithm
        /// </summary>
        /// <value>Whether you provide &#x60;unrealizedPl&#x60; for positions. Otherwise P&amp;L will be calculated automatically based on a simple algorithm</value>
        [DataMember(Name = "supportPLUpdate")]
        public bool? SupportPLUpdate { get; set; }

        /// <summary>
        /// Reserved for future use
        /// </summary>
        /// <value>Reserved for future use</value>
        [DataMember(Name = "supportReducePosition")]
        public bool? SupportReducePosition { get; set; }

        /// <summary>
        /// Whether you support StopLimit orders
        /// </summary>
        /// <value>Whether you support StopLimit orders</value>
        [DataMember(Name = "supportStopLimitOrders")]
        public bool? SupportStopLimitOrders { get; set; }

        /// <summary>
        /// Whether you support /ordersHistory request
        /// </summary>
        /// <value>Whether you support /ordersHistory request</value>
        [DataMember(Name = "supportOrdersHistory")]
        public bool? SupportOrdersHistory { get; set; }

        /// <summary>
        /// Whether you support /executions request
        /// </summary>
        /// <value>Whether you support /executions request</value>
        [DataMember(Name = "supportExecutions")]
        public bool? SupportExecutions { get; set; }

        /// <summary>
        /// Whether you support Digital signature input field in the Order Ticket
        /// </summary>
        /// <value>Whether you support Digital signature input field in the Order Ticket</value>
        [DataMember(Name = "supportDigitalSignature")]
        public bool? SupportDigitalSignature { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountFlags {\n");
            sb.Append("  ShowQuantityInsteadOfAmount: ").Append(ShowQuantityInsteadOfAmount).Append("\n");
            sb.Append("  SupportDOM: ").Append(SupportDOM).Append("\n");
            sb.Append("  SupportBrackets: ").Append(SupportBrackets).Append("\n");
            sb.Append("  SupportOrderBrackets: ").Append(SupportOrderBrackets).Append("\n");
            sb.Append("  SupportPositionBrackets: ").Append(SupportPositionBrackets).Append("\n");
            sb.Append("  SupportClosePosition: ").Append(SupportClosePosition).Append("\n");
            sb.Append("  SupportEditAmount: ").Append(SupportEditAmount).Append("\n");
            sb.Append("  SupportLevel2Data: ").Append(SupportLevel2Data).Append("\n");
            sb.Append("  SupportMultiposition: ").Append(SupportMultiposition).Append("\n");
            sb.Append("  SupportPLUpdate: ").Append(SupportPLUpdate).Append("\n");
            sb.Append("  SupportReducePosition: ").Append(SupportReducePosition).Append("\n");
            sb.Append("  SupportStopLimitOrders: ").Append(SupportStopLimitOrders).Append("\n");
            sb.Append("  SupportOrdersHistory: ").Append(SupportOrdersHistory).Append("\n");
            sb.Append("  SupportExecutions: ").Append(SupportExecutions).Append("\n");
            sb.Append("  SupportDigitalSignature: ").Append(SupportDigitalSignature).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AccountFlags) obj);
        }

        /// <summary>
        /// Returns true if AccountFlags instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountFlags to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountFlags other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ShowQuantityInsteadOfAmount == other.ShowQuantityInsteadOfAmount ||
                    ShowQuantityInsteadOfAmount != null &&
                    ShowQuantityInsteadOfAmount.Equals(other.ShowQuantityInsteadOfAmount)
                ) &&
                (
                    SupportDOM == other.SupportDOM ||
                    SupportDOM != null &&
                    SupportDOM.Equals(other.SupportDOM)
                ) &&
                (
                    SupportBrackets == other.SupportBrackets ||
                    SupportBrackets != null &&
                    SupportBrackets.Equals(other.SupportBrackets)
                ) &&
                (
                    SupportOrderBrackets == other.SupportOrderBrackets ||
                    SupportOrderBrackets != null &&
                    SupportOrderBrackets.Equals(other.SupportOrderBrackets)
                ) &&
                (
                    SupportPositionBrackets == other.SupportPositionBrackets ||
                    SupportPositionBrackets != null &&
                    SupportPositionBrackets.Equals(other.SupportPositionBrackets)
                ) &&
                (
                    SupportClosePosition == other.SupportClosePosition ||
                    SupportClosePosition != null &&
                    SupportClosePosition.Equals(other.SupportClosePosition)
                ) &&
                (
                    SupportEditAmount == other.SupportEditAmount ||
                    SupportEditAmount != null &&
                    SupportEditAmount.Equals(other.SupportEditAmount)
                ) &&
                (
                    SupportLevel2Data == other.SupportLevel2Data ||
                    SupportLevel2Data != null &&
                    SupportLevel2Data.Equals(other.SupportLevel2Data)
                ) &&
                (
                    SupportMultiposition == other.SupportMultiposition ||
                    SupportMultiposition != null &&
                    SupportMultiposition.Equals(other.SupportMultiposition)
                ) &&
                (
                    SupportPLUpdate == other.SupportPLUpdate ||
                    SupportPLUpdate != null &&
                    SupportPLUpdate.Equals(other.SupportPLUpdate)
                ) &&
                (
                    SupportReducePosition == other.SupportReducePosition ||
                    SupportReducePosition != null &&
                    SupportReducePosition.Equals(other.SupportReducePosition)
                ) &&
                (
                    SupportStopLimitOrders == other.SupportStopLimitOrders ||
                    SupportStopLimitOrders != null &&
                    SupportStopLimitOrders.Equals(other.SupportStopLimitOrders)
                ) &&
                (
                    SupportOrdersHistory == other.SupportOrdersHistory ||
                    SupportOrdersHistory != null &&
                    SupportOrdersHistory.Equals(other.SupportOrdersHistory)
                ) &&
                (
                    SupportExecutions == other.SupportExecutions ||
                    SupportExecutions != null &&
                    SupportExecutions.Equals(other.SupportExecutions)
                ) &&
                (
                    SupportDigitalSignature == other.SupportDigitalSignature ||
                    SupportDigitalSignature != null &&
                    SupportDigitalSignature.Equals(other.SupportDigitalSignature)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (ShowQuantityInsteadOfAmount != null)
                    hashCode = hashCode * 59 + ShowQuantityInsteadOfAmount.GetHashCode();
                if (SupportDOM != null)
                    hashCode = hashCode * 59 + SupportDOM.GetHashCode();
                if (SupportBrackets != null)
                    hashCode = hashCode * 59 + SupportBrackets.GetHashCode();
                if (SupportOrderBrackets != null)
                    hashCode = hashCode * 59 + SupportOrderBrackets.GetHashCode();
                if (SupportPositionBrackets != null)
                    hashCode = hashCode * 59 + SupportPositionBrackets.GetHashCode();
                if (SupportClosePosition != null)
                    hashCode = hashCode * 59 + SupportClosePosition.GetHashCode();
                if (SupportEditAmount != null)
                    hashCode = hashCode * 59 + SupportEditAmount.GetHashCode();
                if (SupportLevel2Data != null)
                    hashCode = hashCode * 59 + SupportLevel2Data.GetHashCode();
                if (SupportMultiposition != null)
                    hashCode = hashCode * 59 + SupportMultiposition.GetHashCode();
                if (SupportPLUpdate != null)
                    hashCode = hashCode * 59 + SupportPLUpdate.GetHashCode();
                if (SupportReducePosition != null)
                    hashCode = hashCode * 59 + SupportReducePosition.GetHashCode();
                if (SupportStopLimitOrders != null)
                    hashCode = hashCode * 59 + SupportStopLimitOrders.GetHashCode();
                if (SupportOrdersHistory != null)
                    hashCode = hashCode * 59 + SupportOrdersHistory.GetHashCode();
                if (SupportExecutions != null)
                    hashCode = hashCode * 59 + SupportExecutions.GetHashCode();
                if (SupportDigitalSignature != null)
                    hashCode = hashCode * 59 + SupportDigitalSignature.GetHashCode();
                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(AccountFlags left, AccountFlags right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountFlags left, AccountFlags right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}
