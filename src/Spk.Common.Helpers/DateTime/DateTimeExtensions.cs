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
            return (long) (dt - Epoch).TotalSeconds;
        }

        /// <summary>
        ///     Returns a Unix Epoch time if given a value, and null otherwise.
        /// </summary>
        /// <param name="dt">The <see cref="System.DateTime" /> to convert.</param>
        /// <returns></returns>
        public static long? ToEpochTime(this System.DateTime? dt)
        {
            return dt.HasValue ? (long?) ToEpochTime(dt.Value) : null;
        }
    }
}