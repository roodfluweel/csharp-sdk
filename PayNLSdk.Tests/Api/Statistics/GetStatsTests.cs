using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using PayNLSdk.API.Statistics.GetManagement;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests.Api.Statistics
{
    [SuppressMessage("ReSharper", "RedundantNameQualifier", Justification = "We need to be sure the correct object is called in the tests")]
    public class GetStatsRequestTests
    {
        private readonly PayNLSdk.API.Statistics.GetManagement.Request _sut;

        public GetStatsRequestTests()
        {
            _sut = new PayNLSdk.API.Statistics.GetManagement.Request();
        }

        [Fact]
        public void Ctor_FilterPropertyNotTempty_Always()
        {
            // Arrange


            // Act

            // Assert
            _sut.Filters.ShouldNotBeNull();
            _sut.Filters.Count.ShouldBe(0);
        }

        [Fact]
        public void Ctor_GroupByPropertyNotTempty_Always()
        {
            // Arrange


            // Act

            // Assert
            _sut.GroupByFieldNames.ShouldNotBeNull();
            _sut.GroupByFieldNames.Count.ShouldBe(0);
        }

        [Fact]
        public void GetParameters_ContainsGroupBy_IfSortByFieldNamesPropertyIsUsed()
        {
            // Arrange
            _sut.GroupByFieldNames.Add("ABC");

            // Act
            var result = _sut.GetParameters();

            // Assert
            result.Get("groupBy[0]").ShouldBe("ABC");
        }

        [Fact]
        public void GetParameters_ContainsFilters_MultipleFiltersAdded()
        {
            // Arrange
            _sut.Filters.Add(new Request.FilterItem { Key = "KEY1", Value = "VAL1" });
            _sut.Filters.Add(new Request.FilterItem { Key = "KEY2", Value = "VAL2" });

            // Act
            var result = _sut.GetParameters();

            // Assert
            GetWithPartialKey(result, "filterType[").ShouldContain("KEY1");
            GetWithPartialKey(result, "filterType[").ShouldContain("KEY2");
            GetWithPartialKey(result, "filterValue[").ShouldContain("VAL1");
            GetWithPartialKey(result, "filterValue[").ShouldContain("VAL2");
        }

        [Fact]
        public void Create_CorrectStartEndDate_LastWeek()
        {
            // Arrange
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now.Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime, Request.StatsPeriod.LastWeek);

            // Assert
            result.StartDate.ShouldBe(new DateTime(2018, 12, 3));
            result.EndDate.ShouldBe(new DateTime(2018, 12, 9));
        }

        [Fact]
        public void Create_CorrectStartEndDate_LastMonth()
        {
            // Arrange
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now.Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime, Request.StatsPeriod.LastMonth);

            // Assert
            result.StartDate.ShouldBe(new DateTime(2018, 11, 1));
            result.EndDate.ShouldBe(new DateTime(2018, 11, 30));
        }

        [Fact]
        public void Create_CorrectStartEndDate_ThisWeek()
        {
            // Arrange
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now.Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime, Request.StatsPeriod.ThisWeek);

            // Assert
            result.StartDate.ShouldBe(new DateTime(2018, 12, 10));
            result.EndDate.ShouldBe(new DateTime(2018, 12, 16));
        }

        [Fact]
        public void Create_CorrectStartEndDate_ThisMonth()
        {
            // Arrange
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now.Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime, Request.StatsPeriod.ThisMonth);

            // Assert
            result.StartDate.ShouldBe(new DateTime(2018, 12, 1));
            result.EndDate.ShouldBe(new DateTime(2018, 12, 11));
        }

        /// <summary>
        /// Loops all items in a <see cref="NameValueCollection"/> and
        /// return all values from all keys which start with the <paramref name="keyStartsWith"/>
        /// </summary>
        /// <param name="nvc"></param>
        /// <param name="keyStartsWith"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetWithPartialKey(NameValueCollection nvc, string keyStartsWith)
        {
            if (nvc == null)
            {
                yield break;
            }

            foreach (var s in nvc.AllKeys)
            {
                if (s.ToLower().StartsWith(keyStartsWith.ToLower()))
                {
                    yield return nvc.Get(s);
                }
            }
        }
    }
}
