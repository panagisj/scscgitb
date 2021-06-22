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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models
{
    /// <summary>
    /// Bar marks data.
    /// </summary>
    [DataContract]
    public partial class MarksArrays : IEquatable<MarksArrays>
    {
        /// <summary>
        /// Unique identifiers of marks.
        /// </summary>
        /// <value>Unique identifiers of marks.</value>
        [Required]
        [DataMember(Name = "id")]
        public List<decimal?> Id { get; set; }

        /// <summary>
        /// bar time, unix timestamp (UTC)
        /// </summary>
        /// <value>bar time, unix timestamp (UTC)</value>
        [Required]
        [DataMember(Name = "time")]
        public List<decimal?> Time { get; set; }

        /// <summary>
        /// Mark colors
        /// </summary>
        /// <value>Mark colors</value>
        [DataMember(Name = "color")]
        public List<string> Color { get; set; }

        /// <summary>
        /// mark popup text. HTML supported
        /// </summary>
        /// <value>mark popup text. HTML supported</value>
        [DataMember(Name = "text")]
        public List<string> Text { get; set; }

        /// <summary>
        /// a letter to be printed on a mark. Single character
        /// </summary>
        /// <value>a letter to be printed on a mark. Single character</value>
        [Required]
        [DataMember(Name = "label")]
        public List<string> Label { get; set; }

        /// <summary>
        /// color of a letter on a mark
        /// </summary>
        /// <value>color of a letter on a mark</value>
        [DataMember(Name = "labelFontColor")]
        public List<string> LabelFontColor { get; set; }

        /// <summary>
        /// minimal size of mark (diameter, pixels)
        /// </summary>
        /// <value>minimal size of mark (diameter, pixels)</value>
        [DataMember(Name = "minSize")]
        public List<decimal?> MinSize { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MarksArrays {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  LabelFontColor: ").Append(LabelFontColor).Append("\n");
            sb.Append("  MinSize: ").Append(MinSize).Append("\n");
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
            return obj.GetType() == GetType() && Equals((MarksArrays)obj);
        }

        /// <summary>
        /// Returns true if MarksArrays instances are equal
        /// </summary>
        /// <param name="other">Instance of MarksArrays to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MarksArrays other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.SequenceEqual(other.Id)
                ) &&
                (
                    Time == other.Time ||
                    Time != null &&
                    Time.SequenceEqual(other.Time)
                ) &&
                (
                    Color == other.Color ||
                    Color != null &&
                    Color.SequenceEqual(other.Color)
                ) &&
                (
                    Text == other.Text ||
                    Text != null &&
                    Text.SequenceEqual(other.Text)
                ) &&
                (
                    Label == other.Label ||
                    Label != null &&
                    Label.SequenceEqual(other.Label)
                ) &&
                (
                    LabelFontColor == other.LabelFontColor ||
                    LabelFontColor != null &&
                    LabelFontColor.SequenceEqual(other.LabelFontColor)
                ) &&
                (
                    MinSize == other.MinSize ||
                    MinSize != null &&
                    MinSize.SequenceEqual(other.MinSize)
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
                if (Time != null)
                    hashCode = hashCode * 59 + Time.GetHashCode();
                if (Color != null)
                    hashCode = hashCode * 59 + Color.GetHashCode();
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                if (LabelFontColor != null)
                    hashCode = hashCode * 59 + LabelFontColor.GetHashCode();
                if (MinSize != null)
                    hashCode = hashCode * 59 + MinSize.GetHashCode();
                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(MarksArrays left, MarksArrays right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MarksArrays left, MarksArrays right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}
