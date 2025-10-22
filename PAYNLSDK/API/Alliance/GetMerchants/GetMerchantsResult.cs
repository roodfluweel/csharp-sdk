using System.Collections.Generic;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.GetMerchants
{
    /// <summary>
    /// Result class for GetMerchants call
    /// </summary>
    public class GetMerchantsResult : ResponseBase
    {
        /// <summary>
        /// List of merchants
        /// </summary>
        [JsonProperty("merchants")]
        public List<MerchantInfo> Merchants { get; set; } = new List<MerchantInfo>();
    }

    /// <summary>
    /// Merchant information
    /// </summary>
    public class MerchantInfo
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Merchant name
        /// </summary>
        [JsonProperty("merchantName")]
        public string MerchantName { get; set; }

        /// <summary>
        /// Merchant state
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
