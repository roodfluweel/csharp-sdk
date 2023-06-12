using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// Gender enumeration
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// A male gender
        /// </summary>
        [EnumMember(Value="m")]
        Male,
        /// <summary>
        /// A female gender
        /// </summary>
        [EnumMember(Value = "f")]
        Female
    }
}
