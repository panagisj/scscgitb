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
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models
{
    /// <summary>
    /// Map of Broker instrument names and TradingView instrument names
    /// </summary>
    [DataContract]
    public partial class SymbolMapping : IEquatable<SymbolMapping>
    {
        /// <summary>
        /// Gets or Sets Symbols
        /// </summary>
        [DataMember(Name = "symbols")]
        public List<SingleMapping> Symbols { get; set; }

        /// <summary>
        /// Array with the only one element &#x60;[&#39;brokerSymbol&#39;]&#x60;.
        /// </summary>
        /// <value>Array with the only one element &#x60;[&#39;brokerSymbol&#39;]&#x60;.</value>
        [DataMember(Name = "fields")]
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<SingleField> Fields { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SymbolMapping {\n");
            sb.Append("  Symbols: ").Append(Symbols).Append("\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SymbolMapping)obj);
        }

        /// <summary>
        /// Returns true if SymbolMapping instances are equal
        /// </summary>
        /// <param name="other">Instance of SymbolMapping to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SymbolMapping other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Symbols == other.Symbols ||
                    Symbols != null &&
                    Symbols.SequenceEqual(other.Symbols)
                ) &&
                (
                    Fields == other.Fields ||
                    Fields != null &&
                    Fields.SequenceEqual(other.Fields)
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
                if (Symbols != null)
                    hashCode = hashCode * 59 + Symbols.GetHashCode();
                if (Fields != null)
                    hashCode = hashCode * 59 + Fields.GetHashCode();
                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(SymbolMapping left, SymbolMapping right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SymbolMapping left, SymbolMapping right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}
