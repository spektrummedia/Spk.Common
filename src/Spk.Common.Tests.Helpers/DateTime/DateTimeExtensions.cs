using System;
using NUnit.Framework;
using Spk.Common.Helpers.DateTime;

namespace Spk.Common.Tests.Helpers.DateTime
{
    public class DateTimeExtensions
    {
        [Test]
        public void ToEpochTime_ShouldReturnValidValue()
        {
            var date = new System.DateTime(2014, 1, 1, 6, 0, 0);
            Assert.That(date.ToEpochTime(), Is.EqualTo(1388556000));
        }
    }
}