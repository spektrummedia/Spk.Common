using System;
using System.Collections.Generic;
using System.Linq;

namespace Spk.Common.Helpers.Collection
{
    public static class RemoveWhereExtension
    {
        public static ICollection<TSource> RemoveWhere<TSource>(
            this ICollection<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (!source.Any())
                return source;

            var elements = source.Where(predicate).ToList();
            foreach (var element in elements)
            {
                source.Remove(element);
            }

            return source;
        }
    }

}
