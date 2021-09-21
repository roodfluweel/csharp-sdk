using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// ExchangeState enumeration
    /// </summary>
    public enum ExchangeState
    {
        /// <summary>
        /// The exchange state failed
        /// </summary>
        [EnumMember(Value = "-1")]
        Failed = -1,

        /// <summary>
        /// The exchange was not called
        /// </summary>
        [EnumMember(Value = "0")]
        NotCalled = 0,

        /// <summary>
        /// The exchange call was successful
        /// </summary>
        [EnumMember(Value = "1")]
        Success = 1
    }
}
