using System;
using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Collection
{
    public class CollectionSynchronization<T> : CollectionSynchronization<T, T>
    {
        internal CollectionSynchronization(IEnumerable<T> source, ICollection<T> target) : base(source, target)
        {
            NewItemsMapper = item => item;
        }
    }

    public class CollectionSynchronization<TSource, TTarget>
    {
        protected readonly IEnumerable<TSource> Source;
        protected readonly ICollection<TTarget> Target;
        protected readonly bool IsAssignableFrom = typeof(TTarget).IsAssignableFrom(typeof(TSource));

        protected Func<TSource, TTarget, bool> MatchPredicate = (source, target) => source.Equals(target);
        protected Func<TSource, TTarget> NewItemsMapper;
        protected Action<TSource, TTarget> UpdateAction;

        protected event Action<TSource, TTarget> Inserted;
        protected event Action<TSource, TTarget> Updated;
        protected event Action<TTarget> Removed;

        internal CollectionSynchronization(IEnumerable<TSource> source, ICollection<TTarget> target)
        {
            Source = source.GuardIsNotNull(nameof(source));
            Target = target.GuardIsNotNull(nameof(target));
        }

        public CollectionSynchronization<TSource, TTarget> MatchUsing(Func<TSource, TTarget, bool> matchPredicate)
        {
            MatchPredicate = matchPredicate.GuardIsNotNull(nameof(matchPredicate));
            return this;
        }

        public CollectionSynchronization<TSource, TTarget> MapNewItemsUsing(Func<TSource, TTarget> newItemsMapper)
        {
            NewItemsMapper = newItemsMapper.GuardIsNotNull(nameof(newItemsMapper));
            return this;
        }

        public CollectionSynchronization<TSource, TTarget> UpdateItemsUsing(Action<TSource, TTarget> updateAction)
        {
            UpdateAction = updateAction.GuardIsNotNull(nameof(updateAction));
            return this;
        }

        public CollectionSynchronization<TSource, TTarget> OnUpdate(Action<TSource, TTarget> onUpdateAction)
        {
            Updated += onUpdateAction.GuardIsNotNull(nameof(onUpdateAction));
            return this;
        }

        public CollectionSynchronization<TSource, TTarget> OnUpdate(Action<TTarget> onRemoveAction)
        {
            Removed += onRemoveAction.GuardIsNotNull(nameof(onRemoveAction));
            return this;
        }

        public CollectionSynchronization<TSource, TTarget> OnInsert(Action<TSource, TTarget> onInsertAction)
        {
            Inserted += onInsertAction.GuardIsNotNull(nameof(onInsertAction));
            return this;
        }

        internal void Execute()
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
                {
                    throw new InvalidOperationException(
                        "NewItemsMapper not set. Please set it by calling MapNewItemsUsing");
                }

                var insertedItem = NewItemsMapper(sourceItem);
                Target.Add(insertedItem);
                Inserted?.Invoke(sourceItem, insertedItem);
            }
        }
    }

    public static class CollectionExtensions
    {
        public static void SynchronizeWith<T>(this ICollection<T> target, IEnumerable<T> source,
            Action<CollectionSynchronization<T>> config = null)
        {
            var sync = new CollectionSynchronization<T>(source, target);
            config?.Invoke(sync);
            sync.Execute();
        }

        public static void SynchronizeWith<TSource, TTarget>(this ICollection<TTarget> target,
            IEnumerable<TSource> source, Action<CollectionSynchronization<TSource, TTarget>> config)
        {
            var sync = new CollectionSynchronization<TSource, TTarget>(source, target);
            config(sync);
            sync.Execute();
        }
    }
}
