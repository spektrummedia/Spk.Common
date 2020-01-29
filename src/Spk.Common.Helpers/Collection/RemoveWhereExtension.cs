using System;
using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Collection
{
    public static class RemoveWhereExtension
    {
        public static ICollection<TSource> RemoveWhere<TSource>(
            this ICollection<TSource> source,
            Func<TSource, bool> predicate)
        {
            source.GuardIsNotNull(nameof(source));

            if (!source.Any())
                return source;

            if (source is IList<TSource> list)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (predicate(list[i]))
                    {
                        list.RemoveAt(i);
                    }
                }

                return list;
            }

            source.Where(predicate)
                .ToList()
                .ForEach(x => source.Remove(x));
            return source;
        }
    }
}
