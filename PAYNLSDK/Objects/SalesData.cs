using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Converters;
using System;
using System.Collections.Generic;

namespace PayNlSdk.Objects;

/// <summary>
/// Specification of sales data for a transaction
/// </summary>
public class SalesData
{
    /// <summary>
    /// Invoice date
    /// </summary>
    [JsonPropertyName("invoiceDate"), JsonConverter(typeof(DMYConverter))]
    public DateTime? InvoiceDate { get; set; }

    /// <summary>
    /// Delivery date
    /// </summary>
    [JsonPropertyName("deliveryDate"), JsonConverter(typeof(DMYConverter))]
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// Ordered products specification
    /// </summary>
    [JsonPropertyName("orderData")]
    public List<OrderData> OrderData { get; set; }
}