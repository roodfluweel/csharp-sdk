using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// ActiveState enumeration
    /// </summary>
    public enum ActiveState
    {
        /// <summary>
        /// Is inactive
        /// </summary>
        [EnumMember(Value = "0")]
        Inactive = 0,

        /// <summary>
        /// Is active
        /// </summary>
        [EnumMember(Value = "1")]
        Active = 1
    }
}
