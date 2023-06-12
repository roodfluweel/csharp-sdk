using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// 3D Secure enumeration
    /// </summary>
    public enum Secure
    {
        /// <summary>
        /// No additional security was used
        /// </summary>
        [EnumMember(Value = "0")]
        NotSecure = 0,

        /// <summary>
        /// Security uses Secure3D
        /// </summary>
        [EnumMember(Value = "1")]
        Secure3D = 1
    }
}
