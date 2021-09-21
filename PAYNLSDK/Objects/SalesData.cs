using System;
using Newtonsoft.Json;
using PayNLSdk.Enums;
using PayNLSdk.Converters;
using System.Collections.Generic;

namespace PayNLSdk.Objects
{
    /// <summary>
    /// Specification of sales data for a transaction
    /// </summary>
    public class SalesData
    {
        /// <summary>
        /// Invoice date
        /// </summary>
        [JsonProperty("invoiceDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// Delivery date
        /// </summary>
        [JsonProperty("deliveryDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Ordered products specification
        /// </summary>
        [JsonProperty("orderData")]
        public List<OrderData> OrderData { get; set; }
    }
}
