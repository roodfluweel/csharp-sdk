using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Api;

namespace PayNlSdk.Api.Alliance.Statistics;

/// <summary>
/// Response payload that aggregates statistics per merchant and payment method.
/// </summary>
public class StatisticsResult : ResponseBase
{
    private JsonElement _rawStats;

    /// <summary>
    /// Raw response as returned by the API.
    /// </summary>
    [JsonPropertyName("arrStatsData")]
    public JsonElement RawStats
    {
        get => _rawStats;
        set
        {
            _rawStats = value;
            Merchants = ParseMerchants(value);
        }
    }

    /// <summary>
    /// Aggregated statistics per merchant.
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<MerchantStatistics> Merchants { get; private set; } = Array.Empty<MerchantStatistics>();

    private static IReadOnlyList<MerchantStatistics> ParseMerchants(JsonElement element)
    {
        if (element.ValueKind != JsonValueKind.Array)
        {
            return Array.Empty<MerchantStatistics>();
        }

        var merchants = new List<MerchantStatistics>();

        foreach (var merchantElement in element.EnumerateArray())
        {
            var merchant = new MerchantStatistics
            {
                Id = merchantElement.TryGetProperty("Id", out var id) ? id.GetString() : null,
                Name = merchantElement.TryGetProperty("Label", out var label) ? label.GetString() : null
            };

            if (merchantElement.TryGetProperty("Data", out var paymentMethodArray) && paymentMethodArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var paymentMethodElement in paymentMethodArray.EnumerateArray())
                {
                    var paymentMethod = new PaymentMethodStatistics
                    {
                        Id = paymentMethodElement.TryGetProperty("Id", out var paymentId) ? paymentId.GetString() : null,
                        Name = paymentMethodElement.TryGetProperty("Label", out var paymentLabel) ? paymentLabel.GetString() : null
                    };

                    if (paymentMethodElement.TryGetProperty("Data", out var paymentData) && paymentData.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var paymentSubElement in paymentData.EnumerateArray())
                        {
                            if (!paymentSubElement.TryGetProperty("Data", out var metrics) || metrics.ValueKind != JsonValueKind.Object)
                            {
                                continue;
                            }

                            if (metrics.TryGetProperty("num", out var transactions))
                            {
                                paymentMethod.Transactions += ReadDecimal(transactions);
                            }

                            if (metrics.TryGetProperty("org_tot", out var turnover))
                            {
                                paymentMethod.Turnover += ReadDecimal(turnover);
                            }
                        }
                    }

                    merchant.PaymentMethods.Add(paymentMethod);
                    merchant.Totals.Transactions += paymentMethod.Transactions;
                    merchant.Totals.Turnover += paymentMethod.Turnover;
                }
            }

            merchants.Add(merchant);
        }

        return merchants;
    }

    private static decimal ReadDecimal(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Number => element.GetDecimal(),
            JsonValueKind.String when decimal.TryParse(element.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var value) => value,
            _ => 0m
        };
    }
}

/// <summary>
/// Aggregated metrics for a merchant.
/// </summary>
public class MerchantStatistics
{
    /// <summary>
    /// Merchant identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Merchant name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Metrics per payment method.
    /// </summary>
    public List<PaymentMethodStatistics> PaymentMethods { get; } = new();

    /// <summary>
    /// Totals over all payment methods.
    /// </summary>
    public Totals Totals { get; } = new();
}

/// <summary>
/// Metrics for a specific payment method.
/// </summary>
public class PaymentMethodStatistics
{
    /// <summary>
    /// Payment method identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Payment method name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Number of transactions.
    /// </summary>
    public decimal Transactions { get; set; }

    /// <summary>
    /// Total turnover.
    /// </summary>
    public decimal Turnover { get; set; }
}

/// <summary>
/// Totals aggregated across all payment methods for a merchant.
/// </summary>
public class Totals
{
    /// <summary>
    /// Total number of transactions.
    /// </summary>
    public decimal Transactions { get; set; }

    /// <summary>
    /// Total turnover amount.
    /// </summary>
    public decimal Turnover { get; set; }
}
