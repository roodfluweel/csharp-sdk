using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// PaymentMethodId enumeration
    /// </summary>
    public enum PaymentMethodId
    {
        /// <summary>
        /// Payment with SMS
        /// </summary>
        [EnumMember(Value = "1")]
        Sms = 1,
        /// <summary>
        /// Payment method with fixed price
        /// </summary>
        [EnumMember(Value = "2")]
        PayFixedPrice = 2,
        /// <summary>
        /// Pay per call
        /// </summary>
        [EnumMember(Value = "3")]
        PayPerCall = 3,
        /// <summary>
        /// Pay per transaction
        /// </summary>
        [EnumMember(Value = "4")]
        PayPerTransaction = 4,
        /// <summary>
        /// Pay per minute
        /// </summary>
        [EnumMember(Value = "5")]
        PayPerMinute = 5
    }
}
