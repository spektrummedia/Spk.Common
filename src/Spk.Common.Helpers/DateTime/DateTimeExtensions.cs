using System;
using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.DateTime
{
    public static class DateTimeExtensions
    {
        private static readonly System.DateTime Epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///     Returns a Unix Epoch time given a <see cref="System.DateTime" />
        /// </summary>
        /// <param name="date">The <see cref="System.DateTime" /> to convert.</param>
        /// <returns></returns>
        public static long ToEpochTime(this System.DateTime date)
        {
            return (long)(date - Epoch).TotalSeconds;
        }

        /// <summary>
        ///     Returns a Unix Epoch time if given a value, and null otherwise.
        /// </summary>
        /// <param name="date">The <see cref="System.DateTime" /> to convert.</param>
        /// <returns></returns>
        public static long? ToEpochTime(this System.DateTime? date)
        {
            return date.HasValue ? (long?)ToEpochTime(date.Value) : null;
        }

        /// <summary>
        ///     Returns a boolean if a given date is a working day.
        /// </summary>
        /// <param name="date">The <see cref="System.DateTime" /> to check.</param>
        /// <returns></returns>
        public static bool IsWorkingDay(this System.DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        ///     Returns a boolean if a given date is weekend.
        /// </summary>
        /// <param name="date">The <see cref="System.DateTime" /> to check.</param>
        /// <returns></returns>
        public static bool IsWeekend(this System.DateTime date) => !IsWorkingDay(date);

        /// <summary>
        ///     Returns the next workday of if a date is on the weekend.
        ///     Returns current day if it is a workday.
        /// </summary>
        /// <param name="date">The <see cref="System.DateTime" /> to check.</param>
        /// <returns></returns>
        public static System.DateTime NextWorkday(this System.DateTime date)
        {
            var nextDay = date;
            while (!nextDay.IsWorkingDay())
                nextDay = nextDay.AddDays(1);
            return nextDay;
        }

        /// <summary>
        ///     Returns a boolean if the given date in between the start and the end date inclusively.
        /// </summary>
        /// <param name="date">The <see cref="System.DateTime" /> to check.</param>
        /// <param name="startDate">The start <see cref="System.DateTime" />.</param>
        /// <param name="endDate">The end <see cref="System.DateTime" />.</param>
        /// <returns></returns>
        public static bool IsWithinRange(this System.DateTime date, System.DateTime startDate, System.DateTime endDate)
        {
            return startDate <= date && date <= endDate;
        }

        /// <summary>
        /// Returns a list of <see cref="DateTimePeriod" /> of a specific interval length/>
        /// </summary>
        /// <param name="startDate">The start <see cref="System.DateTime" />(Included)</param>
        /// <param name="endDate">The end <see cref="System.DateTime" />(Included)</param>
        /// <param name="chunkSizeInDays">The maximal length in days of each chunk</param>
        /// <returns></returns>
        public static IEnumerable<DateTimePeriod> Chunk(this System.DateTime startDate, System.DateTime endDate, int chunkSizeInDays)
        {
            if (endDate == System.DateTime.MinValue)
                yield return new DateTimePeriod(startDate, startDate);
            else
            {
                var periodStart = startDate;

                do
                {
                    var periodEnd = periodStart.AddDays(chunkSizeInDays - 1);
                    if (periodEnd > endDate)
                    {
                        periodEnd = endDate;
                    }
                    yield return new DateTimePeriod(periodStart, periodEnd);

                    periodStart = periodEnd.AddDays(1);
                }
                while (periodStart <= endDate);
            }
            
        }
    }
}
