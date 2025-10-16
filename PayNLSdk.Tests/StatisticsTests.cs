using System;
using NSubstitute;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Net;
using PayNLSdk.API.Statistics.GetManagement;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests;

public class StatisticsTests
{
    [Fact]
    public void GetStats_ShouldDefaultGroupByAndDeserializeResponse()
    {
        // Arrange
        var request = new Request
        {
            StartDate = new DateTime(2024, 01, 01),
            EndDate = new DateTime(2024, 01, 31),
            Staffels = false,
            CurrencyId = 2,
            CompanySelect = CompanySelectEnum.Self
        };
        request.GroupByFieldNames.Add("should-be-cleared");
        request.Filters.Add(new Request.FilterItem { Key = "payment_method_id", Value = "10" });

        const string rawResponse = """
{
  "arrStatsData": [
    {
      "Id": "company",
      "Label": "Acme BV",
      "Data": [
        {
          "Id": "turnover",
          "Label": "Turnover",
          "Data": {
            "sum": "123.45",
            "cst": "2.34",
            "num": "3",
            "avg_dur": "1.23",
            "avg_pay": "41.15",
            "pay": "120.11",
            "org_tot": "123.45"
          }
        }
      ]
    }
  ],
  "totals": {
    "sum": "123.45",
    "cst": "2.34",
    "num": "3",
    "avg_dur": "1.23",
    "avg_pay": "41.15",
    "pay": "120.11",
    "org_tot": "123.45"
  }
}
""";

        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Do<RequestBase>(performedRequest => performedRequest.RawResponse = rawResponse))
            .Returns(rawResponse);
        var sut = new Statistics(client);

        // Act
        var result = sut.GetStats(request);

        // Assert
        client.Received(1).PerformRequest(request);
        request.GroupByFieldNames.Count.ShouldBe(1);
        request.GroupByFieldNames.ShouldContain("company_id");

        var statsData = result.ArrStatsData.ShouldHaveSingleItem();
        statsData.GroupedBy.ShouldBe("Acme BV");
        var statsLine = statsData.Data.ShouldHaveSingleItem();
        statsLine.Type.ShouldBe("Turnover");
        statsLine.Data.sum.ShouldBe(123.45m);
        statsLine.Data.cst.ShouldBe(2.34m);
        statsLine.Data.num.ShouldBe(3m);
        statsLine.Data.avg_pay.ShouldBe(41.15m);
        statsLine.Data.pay.ShouldBe(120.11m);
        statsLine.Data.org_tot.ShouldBe(123.45m);
    }

    [Fact]
    public void GetMultiLevelStats_ShouldApplyBothGroupings()
    {
        // Arrange
        var request = new Request
        {
            StartDate = new DateTime(2024, 02, 01),
            EndDate = new DateTime(2024, 02, 29),
            Staffels = true,
            CompanySelect = CompanySelectEnum.All
        };

        const string rawResponse = """
{
  "arrStatsData": [
    {
      "Id": "company",
      "Label": "Acme BV",
      "Data": [
        {
          "Id": "2024-02-01",
          "Label": "2024-02-01",
          "Data": {
            "sum": "45.67",
            "cst": "1.00",
            "num": "2",
            "avg_dur": "0.00",
            "avg_pay": "22.83",
            "pay": "44.67",
            "org_tot": "45.67"
          }
        }
      ]
    }
  ]
}
""";

        var client = Substitute.For<IClient>();
        client.PerformRequest(Arg.Do<RequestBase>(performedRequest => performedRequest.RawResponse = rawResponse))
            .Returns(rawResponse);
        var sut = new Statistics(client);

        // Act
        var result = sut.GetMultiLevelStats(request, string.Empty, string.Empty);

        // Assert
        client.Received(1).PerformRequest(request);
        request.GroupByFieldNames.ShouldContain("company_id");
        request.GroupByFieldNames.ShouldContain("day");
        request.GroupByFieldNames.Count.ShouldBe(2);

        var topLevel = result.TopLevelGroup.ShouldHaveSingleItem();
        topLevel.Label.ShouldBe("Acme BV");
        var nested = topLevel.Data.ShouldHaveSingleItem();
        nested.Data.sum.ShouldBe(45.67m);
        nested.Data.cst.ShouldBe(1.00m);
        nested.Data.num.ShouldBe(2m);
    }
}
