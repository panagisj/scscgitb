/*
 * TradingView REST API Specification for Brokers
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * 
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Position : IEquatable<Position>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id")]
        public string Id { get; set; }

        /// <summary>
        /// Instrument name that is used on a broker&#39;s side
        /// </summary>
        /// <value>Instrument name that is used on a broker&#39;s side</value>
        [Required]
        [DataMember(Name="instrument")]
        public string Instrument { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        /// <value>Quantity</value>
        [Required]
        [DataMember(Name="qty")]
        public decimal? Qty { get; set; }
        /// <summary>
        /// Side. Possible values &ndash; \"buy\" and \"sell\".
        /// </summary>
        /// <value>Side. Possible values &ndash; \"buy\" and \"sell\".</value>
        public enum SideEnum
        { 
            /// <summary>
            /// Enum BuyEnum for buy
            /// </summary>
            [EnumMember(Value = "buy")]
            BuyEnum = 1,
            
            /// <summary>
            /// Enum SellEnum for sell
            /// </summary>
            [EnumMember(Value = "sell")]
            SellEnum = 2
        }

        /// <summary>
        /// Side. Possible values &amp;ndash; \&quot;buy\&quot; and \&quot;sell\&quot;.
        /// </summary>
        /// <value>Side. Possible values &amp;ndash; \&quot;buy\&quot; and \&quot;sell\&quot;.</value>
        [Required]
        [DataMember(Name="side")]
        public SideEnum? Side { get; set; }

        /// <summary>
        /// Average price of position trades
        /// </summary>
        /// <value>Average price of position trades</value>
        [Required]
        [DataMember(Name="avgPrice")]
        public decimal? AvgPrice { get; set; }

        /// <summary>
        /// Unrealized (open) profit/loss
        /// </summary>
        /// <value>Unrealized (open) profit/loss</value>
        [Required]
        [DataMember(Name="unrealizedPl")]
        public decimal? UnrealizedPl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Position {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Instrument: ").Append(Instrument).Append("\n");
            sb.Append("  Qty: ").Append(Qty).Append("\n");
            sb.Append("  Side: ").Append(Side).Append("\n");
            sb.Append("  AvgPrice: ").Append(AvgPrice).Append("\n");
            sb.Append("  UnrealizedPl: ").Append(UnrealizedPl).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Position)obj);
        }

        /// <summary>
        /// Returns true if Position instances are equal
        /// </summary>
        /// <param name="other">Instance of Position to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Instrument == other.Instrument ||
                    Instrument != null &&
                    Instrument.Equals(other.Instrument)
                ) && 
                (
                    Qty == other.Qty ||
                    Qty != null &&
                    Qty.Equals(other.Qty)
                ) && 
                (
                    Side == other.Side ||
                    Side != null &&
                    Side.Equals(other.Side)
                ) && 
                (
                    AvgPrice == other.AvgPrice ||
                    AvgPrice != null &&
                    AvgPrice.Equals(other.AvgPrice)
                ) && 
                (
                    UnrealizedPl == other.UnrealizedPl ||
                    UnrealizedPl != null &&
                    UnrealizedPl.Equals(other.UnrealizedPl)
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
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Instrument != null)
                    hashCode = hashCode * 59 + Instrument.GetHashCode();
                    if (Qty != null)
                    hashCode = hashCode * 59 + Qty.GetHashCode();
                    if (Side != null)
                    hashCode = hashCode * 59 + Side.GetHashCode();
                    if (AvgPrice != null)
                    hashCode = hashCode * 59 + AvgPrice.GetHashCode();
                    if (UnrealizedPl != null)
                    hashCode = hashCode * 59 + UnrealizedPl.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
