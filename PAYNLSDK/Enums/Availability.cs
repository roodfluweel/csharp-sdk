using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// Availability enumeration
    /// </summary>
    public enum Availability
    {
        /// <summary>
        /// Is not unavailable
        /// </summary>
        [EnumMember(Value = "0")]
        Unavailable = 0,

        /// <summary>
        /// Is available
        /// </summary>
        [EnumMember(Value = "1")]
        Available = 1
    }
}
