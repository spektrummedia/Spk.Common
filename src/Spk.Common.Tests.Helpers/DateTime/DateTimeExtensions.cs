using System;
using Spk.Common.Helpers.DateTime;
using Xunit;

namespace Spk.Common.Tests.Helpers.DateTime
{
    public class DateTimeExtensions
    {
        [Fact]
        public void ToEpochTime_ShouldReturnValidValue()
        {
            var date = new System.DateTime(2014, 1, 1, 6, 0, 0);
            Assert.Equal(1388556000, date.ToEpochTime());
        }
    }
}