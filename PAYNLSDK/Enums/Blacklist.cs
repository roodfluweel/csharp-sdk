using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// Blacklist type enumeration
    /// </summary>
    public enum Blacklist
    {
        /// <summary>
        /// not blacklisted
        /// </summary>
        [EnumMember(Value = "0")]
        NotBlacklisted = 0,

        /// <summary>
        /// blacklisted
        /// </summary>
        [EnumMember(Value = "1")]
        Blacklisted = 1,

        /// <summary>
        /// blacklisted by others
        /// </summary>
        [EnumMember(Value = "2")]
        BlacklistedByOthers = 2
    }
}
