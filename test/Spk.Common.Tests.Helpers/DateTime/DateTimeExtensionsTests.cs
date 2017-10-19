using System;
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

        [Fact]
        public void NextWorkday_ShouldReturnMonday_WhenSunday()
        {
            // 2018/01/07 is sunday
            Assert.Equal(
                new System.DateTime(2018, 1, 7).NextWorkday(),
                new System.DateTime(2018, 1, 8)
            );
        }

        [Fact]
        public void NextWorkday_ShouldReturnMonday_WhenSaturday()
        {
            // 2018/01/06 is saturday
            Assert.Equal(
                new System.DateTime(2018, 1, 6).NextWorkday(),
                new System.DateTime(2018, 1, 8)
            );
        }

        [Fact]
        public void NextWorkday_ShouldReturnMonday_WhenMonday()
        {
            // 2018/01/08 is monday
            Assert.Equal(
                new System.DateTime(2018, 1, 8).NextWorkday(),
                new System.DateTime(2018, 1, 8)
            );
        }
    }
}