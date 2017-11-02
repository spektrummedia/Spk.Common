using System;
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

        [Fact]
        public void InRange_ShouldReturnTrue_WhenInRange()
        {
            Assert.True(System.DateTime.Now.InRange(System.DateTime.Now.AddDays(-1), System.DateTime.Now.AddDays(1)));
            Assert.True(System.DateTime.Now.InRange(System.DateTime.Now, System.DateTime.Now.AddDays(1)));
            Assert.True(System.DateTime.Now.InRange(System.DateTime.Now.AddDays(-1), System.DateTime.Now));
        }

        [Fact]
        public void InRange_ShouldReturnTrue_WhenNotInRange()
        {
            Assert.False(System.DateTime.Now.InRange(System.DateTime.Now.AddDays(1), System.DateTime.Now.AddDays(3)));
            Assert.False(System.DateTime.Now.InRange(System.DateTime.Now.AddDays(-2), System.DateTime.Now.AddDays(-1)));
        }
    }
}
