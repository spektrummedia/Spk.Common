using System;
using System.Collections.Generic;
using System.Linq;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class WhereIfExtension
    {
        /// <summary>
        ///     Used when data needs to be filtered depending on a condition, using .Where() method.
        ///     If the condition fails, original source is returned.
        ///     If the condition pass, filtered source is returned.
        /// </summary>
        public static IEnumerable<TSource> WhereIf<TSource>(
            this IEnumerable<TSource> source,
            bool condition,
            Func<TSource, bool> predicate)
        {
            if (condition)
            {
                if (source != null)
                {
                    return source.Where(predicate);
                }
            }

            return source;
        }
    }
}
