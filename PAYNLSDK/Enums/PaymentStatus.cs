using System.Runtime.Serialization;

namespace PayNLSdk.Enums
{
    /// <summary>
    /// Payment status enumeration representing PAYNL Payment statuses
    /// </summary>

    public enum PaymentStatus
    {
#pragma warning disable 1591
        [EnumMember(Value = "-90")]
        CANCEL = -90,
        [EnumMember(Value = "-60")]
        CANCEL_2 = -60,
        [EnumMember(Value = "-82")]
        PARTIAL_REFUND = -82,
        [EnumMember(Value = "-81")]
        REFUND = -81,
        [EnumMember(Value = "-80")]
        EXPIRED = -80,
        [EnumMember(Value = "-72")]
        REFUNDING = -72,
        [EnumMember(Value = "-71")]
        CHARGEBACK_1 = -71,
        [EnumMember(Value = "-70")]
        CHARGEBACK_2 = -70,
        [EnumMember(Value = "-51")]
        PAID_CHECKAMOUNT = -51,
        [EnumMember(Value = "0")]
        WAIT = 0,
        [EnumMember(Value = "20")]
        PENDING_1 = 20,
        [EnumMember(Value = "25")]
        PENDING_2 = 25,
        [EnumMember(Value = "50")]
        PENDING_3 = 50,
        [EnumMember(Value = "90")]
        PENDING_4 = 90,
        [EnumMember(Value = "60")]
        OPEN = 60,
        [EnumMember(Value = "75")]
        CONFIRMED_1 = 75,
        [EnumMember(Value = "76")]
        CONFIRMED_2 = 76,
        [EnumMember(Value = "80")]
        PARTIAL_PAYMENT = 80,
        [EnumMember(Value = "85")]
        VERIFY = 85,
        [EnumMember(Value = "100")]
        PAID = 100,
        [EnumMember(Value = "95")]
        AUTHORIZE = 95,
        [EnumMember(Value = "-63")]
        DENIED = -63,
#pragma warning restore 1591
    }
}
