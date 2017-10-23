using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Spk.Common.Helpers.Guard;

[assembly: InternalsVisibleTo("Spk.Common.Tests.Helpers")]

namespace Spk.Common.Helpers.Collection
{
    /// <summary>
    ///     Performs a one-way synchronization of a target collection with a source collection.
    /// </summary>
    /// <typeparam name="TSource">Type of the items in the source collection</typeparam>
    /// <typeparam name="TTarget">type of the items in the target collection</typeparam>
    public class CollectionSynchronization<TSource, TTarget>
    {
        protected static readonly Type SourceType = typeof(TSource);
        protected static readonly Type TargetType = typeof(TTarget);

        protected readonly IEnumerable<TSource> Source;
        protected readonly ICollection<TTarget> Target;

        /// <summary>
        ///     Default match predicate is using Object.Equals function to evaluate equality. This can be overriden with
        ///     MatchItemsUsing()
        /// </summary>
        protected Func<TSource, TTarget, bool> MatchPredicate = (src, trg) => src.Equals(trg) || trg.Equals(src);

        /// <summary>
        ///     Default new item mapper is a direct assignation when possible, otherwise null
        /// </summary>
        /// <remarks>
        ///     There can be a slight overhead with this, as we are boxing source object by casting it to object prior to the
        ///     final cast.
        /// </remarks>
        protected Func<TSource, TTarget> NewItemsMapper = TargetType.IsAssignableFrom(SourceType)
            ? src => (TTarget) (object) src
            : (Func<TSource, TTarget>) null;

        protected Action<TSource, TTarget> UpdateAction;

        /// <summary>
        /// </summary>
        /// <param name="source">The source collection. This collection won't be mutated; It is the reference</param>
        /// <param name="target">The target collection. This collection will be mutated to reflect source collection contents</param>
        internal CollectionSynchronization(IEnumerable<TSource> source, ICollection<TTarget> target)
        {
            Source = source.GuardIsNotNull(nameof(source));
            Target = target.GuardIsNotNull(nameof(target));
        }

        protected event Action<TSource, TTarget> Inserted;

        protected event Action<TSource, TTarget> Updated;

        protected event Action<TTarget> Removed;

        /// <summary>
        ///     Sets the function to be used to test equality of the items.
        /// </summary>
        /// <param name="matchPredicate"></param>
        /// <returns></returns>
        public CollectionSynchronization<TSource, TTarget> MatchUsing(Func<TSource, TTarget, bool> matchPredicate)
        {
            MatchPredicate = matchPredicate.GuardIsNotNull(nameof(matchPredicate));
            return this;
        }

        /// <summary>
        ///     Sets the function to be used when adding new elements to the target collection. This is required for mixed type
        ///     collections that can't be cast into one another.
        /// </summary>
        /// <param name="newItemsMapper"></param>
        /// <returns></returns>
        public CollectionSynchronization<TSource, TTarget> MapNewItemsUsing(Func<TSource, TTarget> newItemsMapper)
        {
            NewItemsMapper = newItemsMapper.GuardIsNotNull(nameof(newItemsMapper));
            return this;
        }

        /// <summary>
        ///     Sets the action to be used when updating matched items in the target collection.
        /// </summary>
        /// <param name="updateAction"></param>
        /// <returns></returns>
        public CollectionSynchronization<TSource, TTarget> UpdateItemsUsing(Action<TSource, TTarget> updateAction)
        {
            UpdateAction = updateAction.GuardIsNotNull(nameof(updateAction));
            return this;
        }

        /// <summary>
        ///     Sets one or more event hanlder that are triggered on each update of an item
        /// </summary>
        /// <param name="onUpdateActions"></param>
        /// <returns></returns>
        public CollectionSynchronization<TSource, TTarget> OnUpdate(params Action<TSource, TTarget>[] onUpdateActions)
        {
            foreach (var action in onUpdateActions.GuardIsNotNull(nameof(onUpdateActions)))
                Updated += action;
            return this;
        }

        /// <summary>
        ///     Sets one or more event hanlder that are triggered for each removed item
        /// </summary>
        /// <param name="onRemoveActions"></param>
        /// <returns></returns>
        public CollectionSynchronization<TSource, TTarget> OnRemove(params Action<TTarget>[] onRemoveActions)
        {
            foreach (var action in onRemoveActions.GuardIsNotNull(nameof(onRemoveActions)))
                Removed += action;

            return this;
        }

        /// <summary>
        ///     Sets one or more event hanlder that are triggered for each item inserted
        /// </summary>
        /// <param name="onInsertActions"></param>
        /// <returns></returns>
        public CollectionSynchronization<TSource, TTarget> OnInsert(params Action<TSource, TTarget>[] onInsertActions)
        {
            foreach (var action in onInsertActions.GuardIsNotNull(nameof(onInsertActions)))
                Inserted += action;

            return this;
        }

        /// <summary>
        ///     Syncs the target collection with the source collection.
        ///     * Each item in the source not found in the target are added to it.
        ///     * Each item in the target also found in the source are updated.
        ///     * Each item in the target not found in the source are removed.
        /// </summary>
        public void Execute()
        {
            var sourceWorkingList = Source.ToList();

            for (var i = 0; i < Target.Count; i++)
            {
                var targetItem = Target.ElementAt(i);
                var foundInSource = false;
                var sourceItem =
                    sourceWorkingList.FirstOrDefault(src => foundInSource = MatchPredicate(src, targetItem));
                if (foundInSource)
                {
                    UpdateAction?.Invoke(sourceItem, targetItem);
                    sourceWorkingList.Remove(sourceItem);
                    Updated?.Invoke(sourceItem, targetItem);
                }
                else
                {
                    Target.Remove(targetItem);
                    Removed?.Invoke(targetItem);
                    i--;
                }
            }

            foreach (var sourceItem in sourceWorkingList)
            {
                if (NewItemsMapper == null)
                    throw new InvalidOperationException(
                        $"Can't add new item in target collection. Unable to automatically assign {SourceType.Name} to {TargetType.Name}. Please set NewItemsMapper by calling MapNewItemsUsing.");

                var insertedItem = NewItemsMapper.Invoke(sourceItem);

                Target.Add(insertedItem);
                Inserted?.Invoke(sourceItem, insertedItem);
            }
        }
    }

    /// <inheritdoc />
    /// <summary>
    ///     A one-way synchronization of a target collection with a source collection.
    /// </summary>
    /// <typeparam name="T">Type of the items in the collections</typeparam>
    public class CollectionSynchronization<T> : CollectionSynchronization<T, T>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        internal CollectionSynchronization(IEnumerable<T> source, ICollection<T> target) : base(source, target)
        {
            NewItemsMapper = item => item;
        }
    }
}