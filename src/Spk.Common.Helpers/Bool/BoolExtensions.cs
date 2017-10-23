using System;

namespace Spk.Common.Helpers.Bool
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Returns a nullable bool given a <see cref="string" />.
        /// "True", "true" or "TRUE" will returns true.
        /// "False", "false" or "FALSE" will returns false.
        /// "Anything", "null" or null will returns null.
        /// </summary>
        /// <param name="nullableBoolean">The <see cref="string" /> to convert.</param>
        /// <returns><see cref="bool?" /></returns>
        public static bool? ToNullableBool(this string nullableBoolean)
        {
            bool value;
            if (Boolean.TryParse(nullableBoolean, out value))
            {
                return value;
            }
            return null;
        }
    }
}
