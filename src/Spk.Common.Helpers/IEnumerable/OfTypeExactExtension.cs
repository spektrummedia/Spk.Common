using System.Collections.Generic;
using System.Linq;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class OfTypeExactExtension
    {
        /// <summary>
        ///     Returns IEnumerable of filtered data by Type
        /// </summary>
        public static IEnumerable<T> OfTypeExact<T>(this IEnumerable<T> source)
        {
            return source.OfType<T>().Where(it => it.GetType() == typeof (T));
        }
    }
}