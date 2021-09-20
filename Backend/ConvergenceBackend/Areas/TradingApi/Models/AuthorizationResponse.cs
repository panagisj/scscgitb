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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models
{
    /// <summary>
    /// Authorization Response
    /// </summary>
    [DataContract]
    public partial class AuthorizationResponse : IEquatable<AuthorizationResponse>
    {
        /// <summary>
        /// Access token acts as a session ID that the application uses for making requests. This token should be protected as if it were user credentials
        /// </summary>
        /// <value>Access token acts as a session ID that the application uses for making requests. This token should be protected as if it were user credentials</value>
        [Required]
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The time when the token is expired is represented as the number of seconds since the Unix epoch (00:00:00 UTC on 1 January 1970)
        /// </summary>
        /// <value>The time when the token is expired is represented as the number of seconds since the Unix epoch (00:00:00 UTC on 1 January 1970)</value>
        [Required]
        [DataMember(Name = "expiration")]
        public decimal? Expiration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AuthorizationResponse {\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  Expiration: ").Append(Expiration).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AuthorizationResponse) obj);
        }

        /// <summary>
        /// Returns true if AuthorizationResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AuthorizationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthorizationResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    AccessToken == other.AccessToken ||
                    AccessToken != null &&
                    AccessToken.Equals(other.AccessToken)
                ) &&
                (
                    Expiration == other.Expiration ||
                    Expiration != null &&
                    Expiration.Equals(other.Expiration)
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
                if (AccessToken != null)
                    hashCode = hashCode * 59 + AccessToken.GetHashCode();
                if (Expiration != null)
                    hashCode = hashCode * 59 + Expiration.GetHashCode();
                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(AuthorizationResponse left, AuthorizationResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AuthorizationResponse left, AuthorizationResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}
