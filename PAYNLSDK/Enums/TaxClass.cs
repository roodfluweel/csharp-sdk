using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// TaxClass enumeration
    /// </summary>
    public enum TaxClass
    {
        /// <summary>
        /// No tax
        /// </summary>
        [EnumMember(Value = "N")]
        None = 0,

        /// <summary>
        /// A low tax class
        /// </summary>
        [EnumMember(Value = "L")]
        Low = 6,

        /// <summary>
        /// High tax class
        /// </summary>
        [EnumMember(Value = "H")]
        High = 21
    }
}
