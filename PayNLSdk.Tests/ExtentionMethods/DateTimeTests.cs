using System;
using PayNlSdk.ExtentionMethods;
using Shouldly;
using Xunit;

namespace PayNlSdk.Tests.ExtentionMethods
{
    public class DateTimeTests
    {
        [Fact]
        public void LastMonthFirstDay_February_CurrentlyMarch()
        {
            // Arrange
            var initialDate = new DateTime(2018, 2, 5);

            // Act
            var result = initialDate.LastMonthFirstDay();

            // Assert
            result.Year.ShouldBe(2018);
            result.Month.ShouldBe(1);
            result.Day.ShouldBe(1);
        }

        [Fact]
        public void LastMonthFirstDay_DecemberPreviousYear_CurrentlyFirstJanuary()
        {
            // Arrange
            var initialDate = new DateTime(2018, 1, 1);

            // Act
            var result = initialDate.LastMonthFirstDay();

            // Assert
            result.Year.ShouldBe(2017);
            result.Month.ShouldBe(12);
            result.Day.ShouldBe(1);
        }

        [Fact]
        public void LastMonthFirstDay_PreviousMonth_LastDayOfTheMonth()
        {
            // Arrange
            var initialDate = new DateTime(2018, 1, 31);

            // Act
            var result = initialDate.LastMonthFirstDay();

            // Assert
            result.Year.ShouldBe(2017);
            result.Month.ShouldBe(12);
            result.Day.ShouldBe(1);
        }

        [Fact]
        public void LastWeek_PreviousMonday_TodaySaturday()
        {
            // Arrange
            var initialDate = new DateTime(2018, 10, 13);

            // Act
            var result = initialDate.LastWeek(DayOfWeek.Monday);

            // Assert
            result.ShouldBe(new DateTime(2018, 10, 1));
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void LastWeek_PreviousMonday_TodayMonday()
        {
            // Arrange
            var initialDate = new DateTime(2018, 12, 10);

            // Act
            var result = initialDate.LastWeek(DayOfWeek.Monday);

            // Assert
            result.ShouldBe(new DateTime(2018, 12, 3));
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void LastWeek_PreviousMonday_TodaySunday()
        {
            // Arrange
            var initialDate = new DateTime(2018, 12, 9);

            // Act
            var result = initialDate.LastWeek(DayOfWeek.Monday);

            // Assert
            result.ShouldBe(new DateTime(2018, 11, 26));
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void LastMonthLastDay_Lastday_normalconditions()
        {
            // Arrange
            var initialDate = new DateTime(2018, 7, 19);

            // Act
            var result = initialDate.LastMonthLastDay();

            // Assert
            result.Year.ShouldBe(2018);
            result.Month.ShouldBe(6);
            result.Day.ShouldBe(30);
        }

        [Fact]
        public void LastMonthLastDay_31DecemberPreviousYear_CurrentlyFirstJanuary()
        {
            // Arrange
            var initialDate = new DateTime(2018, 1, 1);

            // Act
            var result = initialDate.LastMonthLastDay();

            // Assert
            result.Year.ShouldBe(2017);
            result.Month.ShouldBe(12);
            result.Day.ShouldBe(31);
        }

        [Fact]
        public void LastMonthLastDay_1March_LeapYear()
        {
            // Arrange
            var initialDate = new DateTime(2004, 3, 15);

            // Act
            var result = initialDate.LastMonthLastDay();

            // Assert
            result.Year.ShouldBe(2004);
            result.Month.ShouldBe(2);
            result.Day.ShouldBe(29);
        }

        [Fact]
        public void ThisWeek_ShouldReturnMondayMidnight_WhenDateIsWednesday()
        {
            // Arrange
            var initialDate = new DateTime(2024, 7, 17, 15, 30, 45);

            // Act
            var result = initialDate.ThisWeek(DayOfWeek.Monday);

            // Assert
            result.ShouldBe(new DateTime(2024, 7, 15));
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
            result.TimeOfDay.ShouldBe(TimeSpan.Zero);
        }

        [Fact]
        public void ThisWeek_ShouldRollBackToPreviousWeek_WhenDateIsSunday()
        {
            // Arrange
            var initialDate = new DateTime(2024, 7, 14, 9, 0, 0);

            // Act
            var result = initialDate.ThisWeek(DayOfWeek.Monday);

            // Assert
            result.ShouldBe(new DateTime(2024, 7, 8));
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }
    }
}
