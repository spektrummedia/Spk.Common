using System;

namespace Spk.Common.Helpers.DateTime
{
    public static class DateTimeExtensions
    {
        private static readonly System.DateTime Epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///     Returns a Unix Epoch time given a <see cref="System.DateTime" />
        /// </summary>
        /// <param name="dt">The <see cref="System.DateTime" /> to convert.</param>
        /// <returns></returns>
        public static long ToEpochTime(this System.DateTime dt)
        {
            return (long)(dt - Epoch).TotalSeconds;
        }

        /// <summary>
        ///     Returns a Unix Epoch time if given a value, and null otherwise.
        /// </summary>
        /// <param name="dt">The <see cref="System.DateTime" /> to convert.</param>
        /// <returns></returns>
        public static long? ToEpochTime(this System.DateTime? dt)
        {
            return dt.HasValue ? (long?)ToEpochTime(dt.Value) : null;
        }

        /// <summary>
        ///     Returns a boolean if a given date is a working day.
        /// </summary>
        /// <param name="dt">The <see cref="System.DateTime" /> to check.</param>
        /// <returns></returns>
        public static bool IsWorkingDay(this System.DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        ///     Returns a boolean if a given date is weekend.
        /// </summary>
        /// <param name="dt">The <see cref="System.DateTime" /> to check.</param>
        /// <returns></returns>
        public static bool IsWeekend(this System.DateTime date) => !IsWorkingDay(date);
    }
}