using System;
using System.Collections.Generic;

namespace Spk.Common.Helpers.Collection
{
    public static class CollectionExtensions
    {
        public static void SynchronizeWith<TSource, TTarget>(this ICollection<TTarget> target, IEnumerable<TSource> source, Action<CollectionSynchronization<TSource, TTarget>> config = null)
        {
            var sync = new CollectionSynchronization<TSource,TTarget>(source, target);
            config?.Invoke(sync);
            sync.Execute();
        }
    }
}
