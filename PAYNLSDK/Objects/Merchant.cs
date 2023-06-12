using System;
using Newtonsoft.Json;
using PayNLSdk.Enums;

namespace PayNLSdk.Objects
{
    /// <summary>
    /// Merchant information
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Merchant Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Merchant Public Name
        /// </summary>
        [JsonProperty("publicName")]
        public string PublicName { get; set; }

        /// <summary>
        /// Active State of the merchant
        /// </summary>
        [JsonProperty("state")]
        public ActiveState State { get; set; }

    }
}
