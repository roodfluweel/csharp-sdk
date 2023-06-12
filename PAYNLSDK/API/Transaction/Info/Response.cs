using System;
using Newtonsoft.Json;
using PayNLSdk.Objects;

namespace PayNLSdk.API.Transaction.Info
{
    /// <summary>
    /// The response of a Transaction Info Call
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connection")]
        public Connection Connection { get; protected set; }

        /// <summary>
        /// information about the enduser
        /// </summary>
        [JsonProperty("enduser")]
        public EndUser EndUser { get; protected set; }

        //[JsonProperty("saledata")]
        //public SalesData SalesData { get; protected set; }

        /// <summary>
        /// All details from the payment
        /// </summary>
        [JsonProperty("paymentDetails")]
        public PaymentDetails PaymentDetails { get; protected set; }

        /// <summary>
        /// Details regarding the refund (if any)
        /// </summary>
        [JsonProperty("stornoDetails")]
        public StornoDetails StornoDetails { get; protected set; }

        /// <summary>
        /// details statistics
        /// </summary>
        [JsonProperty("statsDetails")]
        public StatsDetails StatsDetails { get; protected set; }

    }
}
