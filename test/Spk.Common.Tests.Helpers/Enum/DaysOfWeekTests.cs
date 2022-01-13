using Shouldly;
using Spk.Common.Helpers.Enum;
using Xunit;

namespace Spk.Common.Tests.Helpers.Enum
{
    public class DaysOfWeekTests
    {
        [Fact]
        public void DaysOfWeek_ShouldHaveNoneState()
        {
            var daysOfWeek = DaysOfWeek.None;

            daysOfWeek.ShouldBe(DaysOfWeek.None);
        }

        [Fact]
        public void DaysOfWeek_SaturdayAndSunday_ShouldMatchForWeekends()
        {
            var daysOfWeek = DaysOfWeek.Saturday | DaysOfWeek.Sunday;

            daysOfWeek.ShouldBe(DaysOfWeek.Weekends);
        }

        [Fact]
        public void DaysOfWeek_MondayTuesdayWednesdayThursdayFriday_ShouldMatchForWeekdays()
        {
            var daysOfWeek = DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday;

            daysOfWeek.ShouldBe(DaysOfWeek.Weekdays);
        }

        [Fact]
        public void DaysOfWeek_SundayMondayTuesdayWednesdayThursdayFridaySaturday_ShouldMatchForEveryDay()
        {
            var daysOfWeek = DaysOfWeek.Sunday | DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday | DaysOfWeek.Saturday;

            daysOfWeek.ShouldBe(DaysOfWeek.EveryDay);
        }
    }
}
