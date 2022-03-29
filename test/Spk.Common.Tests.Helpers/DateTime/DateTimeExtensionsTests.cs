using System.Linq;
using Shouldly;
using Spk.Common.Helpers.DateTime;
using Xunit;

namespace Spk.Common.Tests.Helpers.DateTime
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ToEpochTime_ShouldReturnValidValue()
        {
            var date = new System.DateTime(2014, 1, 1, 6, 0, 0);
            Assert.Equal(1388556000, date.ToEpochTime());
        }

        [Fact]
        public void ToEpochTime_ShouldReturnNullWhenValueIsNull()
        {
            System.DateTime? value = null;
            value.ToEpochTime().ShouldBe(null);
        }

        [Fact]
        public void IsWorkingDay_ShouldReturnTrue_WhenWorkingDay()
        {
            // 2018/01/01 is a monday
            Assert.True(new System.DateTime(2018, 1, 1).IsWorkingDay());
            Assert.True(new System.DateTime(2018, 1, 2).IsWorkingDay());
            Assert.True(new System.DateTime(2018, 1, 3).IsWorkingDay());
            Assert.True(new System.DateTime(2018, 1, 4).IsWorkingDay());
            Assert.True(new System.DateTime(2018, 1, 5).IsWorkingDay());
        }

        [Fact]
        public void IsWorkingDay_ShouldReturnFalse_WhenNotWorkingDay()
        {
            // 2018/01/06 is saturday
            Assert.False(new System.DateTime(2018, 1, 6).IsWorkingDay());
            Assert.False(new System.DateTime(2018, 1, 7).IsWorkingDay());
        }

        [Fact]
        public void IsWeekend_ShouldReturnFalse_WhenWorkingDay()
        {
            // 2018/01/01 is a monday
            Assert.False(new System.DateTime(2018, 1, 1).IsWeekend());
            Assert.False(new System.DateTime(2018, 1, 2).IsWeekend());
            Assert.False(new System.DateTime(2018, 1, 3).IsWeekend());
            Assert.False(new System.DateTime(2018, 1, 4).IsWeekend());
            Assert.False(new System.DateTime(2018, 1, 5).IsWeekend());
        }

        [Fact]
        public void IsWeekend_ShouldReturnTrue_WhenNotWorkingDay()
        {
            // 2018/01/06 is saturday
            Assert.True(new System.DateTime(2018, 1, 6).IsWeekend());
            Assert.True(new System.DateTime(2018, 1, 7).IsWeekend());
        }

        [Theory]
        [InlineData(2018, 1, 6)] // saturday
        [InlineData(2018, 1, 7)]
        public void NextWorkday_ShouldReturnMonday_WhenWeekEnd(int year, int month, int day)
        {
            Assert.Equal(
                new System.DateTime(year, month, day).NextWorkday(),
                new System.DateTime(2018, 1, 8) // monday
            );
        }

        [Theory]
        [InlineData(2018, 1, 8)] // monday
        [InlineData(2018, 1, 9)]
        [InlineData(2018, 1, 10)]
        [InlineData(2018, 1, 11)]
        [InlineData(2018, 1, 12)]
        public void NextWorkday_ShouldReturnSameDay_WhenWorkday(int year, int month, int day)
        {
            var date = new System.DateTime(year, month, day);
            date.NextWorkday().ShouldBe(date);
        }

        [Theory]
        [InlineData(10, 10, 11)]
        [InlineData(10, 9, 11)]
        [InlineData(10, 9, 10)]
        public void InRange_ShouldReturnTrue_WhenInRange(int dayUndertest,int lowerDay, int upperDay)
        {
            var dateUnderTest = new System.DateTime(2018, 10, dayUndertest);
            var lower = new System.DateTime(2018, 10, lowerDay);
            var upper = new System.DateTime(2018, 10, upperDay);

            dateUnderTest.IsWithinRange(lower, upper).ShouldBeTrue();
        }

        [Theory]
        [InlineData(10, 11, 12)]
        [InlineData(10, 8, 9)]
        public void InRange_ShouldReturnTrue_WhenNotInRange(int dayUnderTest, int lowerDay, int upperDay)
        {
            var dateUnderTest = new System.DateTime(2018, 10, dayUnderTest);
            var lower = new System.DateTime(2018, 10, lowerDay);
            var upper = new System.DateTime(2018, 10, upperDay);

            dateUnderTest.IsWithinRange(lower, upper).ShouldBeFalse();
        }

        [Theory]
        [InlineData("2022-01-01", "2022-01-04", 2, 2)]
        [InlineData("2022-01-01", "2022-01-05", 2, 3)]
        [InlineData("2022-01-01", "2022-01-02", 2, 1)]
        [InlineData("2022-01-01", "2022-01-30", 15, 2)]
        [InlineData("2022-01-01", "2022-01-30", 30, 1)]
        [InlineData("2021-01-01", "2022-01-01", 183, 2)]
        [InlineData("2021-01-01", null, 10, 1)]
        public void Chunk_ShouldReturn_TheExpectedNumberOfDateRange_BasedOnChunkSize(string startDate, string endDate, int chunkSizeInDays, int expectedNumberOfChunks)
        {
            System.DateTime.TryParse(startDate, out System.DateTime s);
            System.DateTime.TryParse(endDate, out System.DateTime e);

            var chunks =  s.Chunk(e, chunkSizeInDays);

            chunks.Count().ShouldBe(expectedNumberOfChunks);
        }

        [Theory]
        [InlineData("2022-01-01", "2022-01-05", 2)]
        [InlineData("2022-01-01", "2022-01-30", 15)]
        [InlineData("2022-01-01", "2022-01-30", 30)]
        [InlineData("2021-01-01", "2022-01-01", 183)]
        [InlineData("2021-01-01", null, 10)]
        public void Chunk_ShouldReturn_RangeSizeLowerOrEqualToChunkSize(string startDate, string endDate, int chunkSizeInDays)
        {
            System.DateTime.TryParse(startDate, out System.DateTime s);
            System.DateTime.TryParse(endDate, out System.DateTime e);

            var chunks = s.Chunk(e, chunkSizeInDays);

            chunks.ShouldAllBe(period => (period.End - period.Begin).Days <= chunkSizeInDays);
        }
    }
}
