using System.Collections.Generic;
using System.Linq;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class ExtractDuplicatesExtension
    {
        /// <summary>
        ///     Extract duplicates from an IEnumerable of primitive type ojects.
        /// </summary>
        public static IEnumerable<T> ExtractDuplicates<T>(this IEnumerable<T> source)
        {
            return source
                .GroupBy(item => item)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);
        }
    }
}
