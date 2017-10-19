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
    }
}