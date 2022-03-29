using System;
using Shouldly;
using Spk.Common.Helpers.DateTime;
using Xunit;

namespace Spk.Common.Tests.Helpers.DateTime
{
    public class DateTimePeriodTests
    {
        [Theory]
        [InlineData("2022-01-01", "2022-01-01", 1)]
        [InlineData("2022-01-01", "2022-01-02", 2)]
        public void Days_ShouldReturn_NumberOfDaysBetweenBeginAndEndDateInclusively(string startDate, string endDate, int expectedPeriodLength)
        {
            System.DateTime.TryParse(startDate, out System.DateTime s);
            System.DateTime.TryParse(endDate, out System.DateTime e);

            var period = new DateTimePeriod(s, e);

            period.Days.ShouldBe(expectedPeriodLength);
        }

        [Fact]
        public void Days_ShouldThrows_WhenEndIsEarlierThanBegin()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = new DateTimePeriod(System.DateTime.Parse("2022-01-01"), System.DateTime.Parse("2021-12-31"));
            });
            
        }
    }
}
