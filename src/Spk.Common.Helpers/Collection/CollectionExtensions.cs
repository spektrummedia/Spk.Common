using System;
using System.Collections.Generic;

namespace Spk.Common.Helpers.Collection
{
    public static class CollectionExtensions
    {
        /// <summary>
        ///     Performs a one-way synchronization of a target collection with a source collection.
        /// </summary>
        /// <typeparam name="TSource">Type of the items in the source collection</typeparam>
        /// <typeparam name="TTarget">type of the items in the target collection</typeparam>
        /// <param name="target">The target collection. This collection will be mutated to reflect source collection contents</param>
        /// <param name="source">The source collection. This collection won't be mutated; It is the reference</param>
        /// <param name="config">Action used to configure the CollectionSynchronization object before execution</param>
        public static void SynchronizeWith<TSource, TTarget>(
            this ICollection<TTarget> target,
            IEnumerable<TSource> source, 
            Action<CollectionSynchronization<TSource, TTarget>> config = null)
        {
            var sync = new CollectionSynchronization<TSource, TTarget>(source, target);
            config?.Invoke(sync);
            sync.Execute();
        }

        /// <summary>
        ///     Performs a one-way synchronization of a target collection with a source collection.
        /// </summary>
        /// <typeparam name="T">Type of the items in the collections</typeparam>
        /// <param name="target">The target collection. This collection will be mutated to reflect source collection contents</param>
        /// <param name="source">The source collection. This collection won't be mutated; It is the reference</param>
        /// <param name="config">Action used to configure the CollectionSynchronization object before execution</param>
        public static void SynchronizeWith<T>(
            this ICollection<T> target,
            IEnumerable<T> source, 
            Action<CollectionSynchronization<T>> config = null)
        {
            var sync = new CollectionSynchronization<T>(source, target);
            config?.Invoke(sync);
            sync.Execute();
        }
    }
}