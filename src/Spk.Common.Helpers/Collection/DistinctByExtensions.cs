using System;
using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Collection
{
    public static class DistinctByExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector) where TKey : IEquatable<TKey>
        {
            source.GuardIsNotNull(nameof(source));
            keySelector.GuardIsNotNull(nameof(keySelector));

            return source.GroupBy(keySelector).Select(x => x.First());
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, bool> predicate) where TKey : IEquatable<TKey> where TSource : class
        {
            source.GuardIsNotNull(nameof(source));
            keySelector.GuardIsNotNull(nameof(keySelector));
            predicate.GuardIsNotNull(nameof(predicate));

            return source.GroupBy(keySelector).Select(x => x.FirstOrDefault(predicate) ?? x.First());
        }
    }
}
