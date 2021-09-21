using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// Type of the order line.
    /// </summary>
    public enum ProductType
    {
#pragma warning disable 1591
        [EnumMember(Value = "ARTICLE")]
        ARTICLE,
        [EnumMember(Value = "SHIPPING")]
        SHIPPING,
        [EnumMember(Value = "HANDLING")]
        HANDLING,
        [EnumMember(Value = "DISCOUNT")]
        DISCOUNT,
        [EnumMember(Value = "ARTICLE_H")]
        ARTICLE_H,
        [EnumMember(Value = "VOUCHER")]
        VOUCHER,
        [EnumMember(Value = "GIFTCARD")]
        GIFTCARD,
        [EnumMember(Value = "EMONEY")]
        EMONEY,
        [EnumMember(Value = "TOPUP")]
        TOPUP,
        [EnumMember(Value = "TICKET")]
        TICKET,
        [EnumMember(Value = "CRYPTO")]
        CRYPTO,
        [EnumMember(Value = "IDENTITY")]
        IDENTITY,
        [EnumMember(Value = "INVOICE")]
        INVOICE,
        [EnumMember(Value = "DOWNLOAD")]
        DOWNLOAD,
        [EnumMember(Value = "VIRTUAL")]
        VIRTUAL,
        [EnumMember(Value = "CREDIT")]
        CREDIT,
        [EnumMember(Value = "PAYMENT")]
        PAYMENT,
        [EnumMember(Value = "ROUNDING")]
        ROUNDING,
#pragma warning restore 1591
    }
}
