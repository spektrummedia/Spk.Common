using System;
using System.Collections.Generic;
using Moq;
using Shouldly;
using Spk.Common.Helpers.Collection;
using Xunit;

namespace Spk.Common.Tests.Helpers.Collections
{
    public class CollectionSynchronizationTests
    {
        [Fact]
        public void Execute_ShouldAddNewItemsUsingNewItemsMapper_WhenNewItemsMapperIsSet()
        {
            var sourceItem1 = new SomeRandomClass { String = "item #1" };
            var sourceItem2 = new SomeRandomClass { String = "item #2" };

            var source = new List<SomeRandomClass>
            {
                sourceItem1,
                sourceItem2
            };

            var target = new List<SomeRandomClass>();

            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(source, target);
            sync.MapNewItemsUsing(src => new SomeRandomClass { String = $"this is a new {src.String}" });
            sync.Execute();

            target.Count.ShouldBe(2);

            target.ShouldNotContain(sourceItem1);
            target.ShouldNotContain(sourceItem2);

            target.ShouldContain(item => item.String == "this is a new item #1");
            target.ShouldContain(item => item.String == "this is a new item #2");
        }

        [Fact]
        public void
            Execute_ShouldAddNotMatchedItemsFromSource_AndRemoveNotMatchedItemsFromTarget_MatchingUsingEquals_WhenMatchFunctionNotProvided()
        {
            var shouldBeAdded1 = new SomeRandomClassEqualsCaseInsensitiveString { String = "one" };

            var source = new List<SomeRandomClass>
            {
                new SomeRandomClass {String = "two"},
                new SomeRandomClassEqualsCaseInsensitiveString {String = "THREE"},
                shouldBeAdded1
            };

            var shouldBeMatched2 = new SomeRandomClassEqualsCaseInsensitiveString { String = "TWO" };
            var shouldBeMatched3 = new SomeRandomClass { String = "three" };

            var shouldBeRemoved = new SomeRandomClassEqualsCaseInsensitiveString { String = "not matched :(" };

            var target = new List<SomeRandomClass>
            {
                shouldBeMatched2,
                shouldBeMatched3,
                shouldBeRemoved
            };

            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(source, target);

            sync.Execute();

            target.Count.ShouldBe(3);

            target.ShouldContain(shouldBeAdded1);
            target.ShouldContain(shouldBeMatched2);
            target.ShouldContain(shouldBeMatched3);

            target.ShouldNotContain(shouldBeRemoved);
        }

        [Fact]
        public void
            Execute_ShouldAddNotMatchedItemsFromSource_AndRemoveNotMatchedItemsFromTarget_UsingProvidedMatchFunction()
        {
            var expected1 = new SomeRandomClass { String = "4" };
            var expected2 = new SomeRandomClass { String = "2 match!" };
            var expected3 = new SomeRandomClass { String = "3 match!" };
            var notExpected = new SomeRandomClass { String = "not matched :(" };

            var source = new List<SomeRandomClass>
            {
                new SomeRandomClass {String = "2"},
                new SomeRandomClass {String = "3"},
                expected1
            };

            var target = new List<SomeRandomClass>
            {
                expected2,
                expected3,
                notExpected
            };

            bool MatchFunction(SomeRandomClass src, SomeRandomClass trg)
            {
                return trg.String == $"{src.String} match!";
            }

            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(source, target);
            sync.MatchUsing(MatchFunction);
            sync.Execute();

            target.Count.ShouldBe(3);

            target.ShouldContain(expected1);
            target.ShouldContain(expected2);
            target.ShouldContain(expected3);
            target.ShouldNotContain(notExpected);
        }

        [Fact]
        public void Execute_ShouldAddObjectsInTarget_WhenNewItemsMapperNotSet_AndTargetIsAssignableFromSource()
        {
            var expected1 = new ChildClass();
            var expected2 = new ChildClass();

            var source = new List<ChildClass>
            {
                expected1,
                expected2
            };

            var target = new List<BaseClass>();

            var sync = new CollectionSynchronization<ChildClass, BaseClass>(source, target);
            sync.Execute();

            target.Count.ShouldBe(2);
            target.ShouldContain(expected1);
            target.ShouldContain(expected2);
        }

        [Fact]
        public void Execute_ShouldThrow_WhenNewItemsMapperNotSet_AndTargetIsNotAssignableFromSource()
        {
            var expected1 = new ChildClass();
            var expected2 = new ChildClass();

            var source = new List<ChildClass>
            {
                expected1,
                expected2
            };

            var target = new List<SomeRandomClass>();

            var sync = new CollectionSynchronization<ChildClass, SomeRandomClass>(source, target);

            Assert.Throws<InvalidOperationException>(() => sync.Execute());
        }

        [Fact]
        public void Execute_ShouldInvokeAllOnInsertFunctionRegistered()
        {
            var sync = new CollectionSynchronization<int, int>(
                new List<int> { 1, 3 },
                new List<int> { 2, 4, 6 }
            );

            var tracker1 = new Mock<EventHandlerTracker<int, int>>();
            var tracker2 = new Mock<EventHandlerTracker<int, int>>();
            var tracker3 = new Mock<EventHandlerTracker<int, int>>();

            sync.OnInsert(tracker1.Object.OnInsertAction, tracker3.Object.OnInsertAction);
            sync.OnInsert(tracker2.Object.OnInsertAction);

            sync.Execute();

            tracker1.Verify(t => t.OnInsertAction(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
            tracker2.Verify(t => t.OnInsertAction(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
            tracker3.Verify(t => t.OnInsertAction(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
        }

        [Fact]
        public void Execute_ShouldInvokeOnInsertFunctionWithCorrectArgument()
        {
            var sourceItem1 = new SomeRandomClass();
            var sourceItem2 = new SomeRandomClass();
            var targetCollection = new List<SomeRandomClass>();

            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass> { sourceItem1, sourceItem2 },
                targetCollection
            );

            var tracker = new Mock<EventHandlerTracker<SomeRandomClass, SomeRandomClass>>();

            sync.OnInsert(tracker.Object.OnInsertAction);
            sync.Execute();

            tracker.Verify(t => t.OnInsertAction(
                It.Is<SomeRandomClass>(src => ReferenceEquals(src, sourceItem1)),
                It.Is<SomeRandomClass>(trg => targetCollection.Contains(trg))),
                Times.Once);

            tracker.Verify(t => t.OnInsertAction(
                It.Is<SomeRandomClass>(src => ReferenceEquals(src, sourceItem2)),
                It.Is<SomeRandomClass>(trg => targetCollection.Contains(trg))),
                Times.Once);
        }

        [Fact]
        public void Execute_ShouldInvokeAllOnUpdateFunctionRegistered()
        {
            var sync = new CollectionSynchronization<int, int>(
                new List<int> { 4, 6 },
                new List<int> { 2, 4, 6 }
            );

            var tracker1 = new Mock<EventHandlerTracker<int, int>>();
            var tracker2 = new Mock<EventHandlerTracker<int, int>>();
            var tracker3 = new Mock<EventHandlerTracker<int, int>>();

            sync.OnUpdate(tracker1.Object.OnUpdateAction, tracker3.Object.OnUpdateAction);
            sync.OnUpdate(tracker2.Object.OnUpdateAction);

            sync.Execute();

            tracker1.Verify(t => t.OnUpdateAction(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
            tracker2.Verify(t => t.OnUpdateAction(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
            tracker3.Verify(t => t.OnUpdateAction(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
        }

        [Fact]
        public void Execute_ShouldInvokeOnUpdateFunctionWithCorrectArgument()
        {
            var sourceItem1 = new SomeRandomClass { String = "one" };
            var targetItem1 = new SomeRandomClass { String = "one" };
            
            var sourceItem2 = new SomeRandomClass { String = "two" };
            var targetItem2 = new SomeRandomClass { String = "two" };

            var targetCollection = new List<SomeRandomClass> { targetItem1, targetItem2 };

            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass> { sourceItem1, sourceItem2 },
                targetCollection
            );

            var tracker = new Mock<EventHandlerTracker<SomeRandomClass, SomeRandomClass>>();

            sync.MatchUsing((src, trg) => src.String == trg.String);
            sync.OnUpdate(tracker.Object.OnUpdateAction);
            sync.Execute();

            tracker.Verify(t => t.OnUpdateAction(
                It.Is<SomeRandomClass>(src => ReferenceEquals(src, sourceItem1)),
                It.Is<SomeRandomClass>(trg => targetCollection.Contains(trg) && ReferenceEquals(trg, targetItem1))),
                Times.Once);

            tracker.Verify(t => t.OnUpdateAction(
                    It.Is<SomeRandomClass>(src => ReferenceEquals(src, sourceItem2)),
                    It.Is<SomeRandomClass>(trg => targetCollection.Contains(trg) && ReferenceEquals(trg, targetItem2))),
                Times.Once);   
        }

        [Fact]
        public void Execute_ShouldInvokeAllOnRemoveFunctionRegistered()
        {
            var sync = new CollectionSynchronization<int, int>(
                new List<int> { 4, 6 },
                new List<int> { 2, 4, 6, 9 }
            );

            var tracker1 = new Mock<EventHandlerTracker<int, int>>();
            var tracker2 = new Mock<EventHandlerTracker<int, int>>();
            var tracker3 = new Mock<EventHandlerTracker<int, int>>();

            sync.OnRemove(tracker1.Object.OnRemoveAction, tracker3.Object.OnRemoveAction);
            sync.OnRemove(tracker2.Object.OnRemoveAction);

            sync.Execute();

            tracker1.Verify(t => t.OnRemoveAction(It.IsAny<int>()), Times.Exactly(2));
            tracker2.Verify(t => t.OnRemoveAction(It.IsAny<int>()), Times.Exactly(2));
            tracker3.Verify(t => t.OnRemoveAction(It.IsAny<int>()), Times.Exactly(2));
        }

        [Fact]
        public void Execute_ShouldInvokeOnRemoveFunctionWithCorrectArgument()
        {
            var targetItem1 = new SomeRandomClass();
            var targetItem2 = new SomeRandomClass();

            var targetCollection = new List<SomeRandomClass> { targetItem1, targetItem2 };

            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                targetCollection
            );

            var tracker = new Mock<EventHandlerTracker<SomeRandomClass, SomeRandomClass>>();

            sync.OnRemove(tracker.Object.OnRemoveAction);
            sync.Execute();

            tracker.Verify(t => t.OnRemoveAction(
                It.Is<SomeRandomClass>(trg => ReferenceEquals(trg, targetItem1))),
                Times.Once);

            tracker.Verify(t => t.OnRemoveAction(
                It.Is<SomeRandomClass>(trg => ReferenceEquals(trg, targetItem2))),
                Times.Once);
        }

        [Fact]
        public void MapNewItemsUsing_ShouldReturnInstance()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            sync.MapNewItemsUsing(src => src).ShouldBeSameAs(sync);
        }

        [Fact]
        public void MapNewItemsUsing_ShouldThrow_WhenArgumentNull()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            Assert.Throws<ArgumentNullException>(() => { sync.MapNewItemsUsing(null); });
        }

        [Fact]
        public void MatchUsing_ShouldReturnInstance()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            sync.MatchUsing((src, trg) => src == trg).ShouldBeSameAs(sync);
        }

        [Fact]
        public void MatchUsing_ShouldThrow_WhenArgumentNull()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            Assert.Throws<ArgumentNullException>(() => { sync.MatchUsing(null); });
        }

        [Fact]
        public void OnInsert_ShouldReturnInstance()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            sync.OnInsert((src, trg) => { }).ShouldBeSameAs(sync);
        }

        [Fact]
        public void OnInsert_ShouldThrow_WhenArgumentNull()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            Assert.Throws<ArgumentNullException>(() => { sync.OnInsert(null); });
        }

        [Fact]
        public void OnRemove_ShouldReturnInstance()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            sync.OnRemove(trg => { }).ShouldBeSameAs(sync);
        }

        [Fact]
        public void OnRemove_ShouldThrow_WhenArgumentNull()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            Assert.Throws<ArgumentNullException>(() => { sync.OnRemove(null); });
        }

        [Fact]
        public void OnUpdate_ShouldReturnInstance()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            sync.OnUpdate((src, trg) => { }).ShouldBeSameAs(sync);
        }

        [Fact]
        public void OnUpdate_ShouldThrow_WhenArgumentNull()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            Assert.Throws<ArgumentNullException>(() => { sync.OnUpdate(null); });
        }

        [Fact]
        public void UpdateItemsUsing_ShouldReturnInstance()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            sync.UpdateItemsUsing((src, trg) => { }).ShouldBeSameAs(sync);
        }

        [Fact]
        public void UpdateItemsUsing_ShouldThrow_WhenArgumentNull()
        {
            var sync = new CollectionSynchronization<SomeRandomClass, SomeRandomClass>(
                new List<SomeRandomClass>(),
                new List<SomeRandomClass>()
            );

            Assert.Throws<ArgumentNullException>(() => { sync.UpdateItemsUsing(null); });
        }
    }

    #region Helper classes

    public class EventHandlerTracker<TSource, TTarget>
    {
        public virtual void OnInsertAction(TSource source, TTarget target)
        {
        }

        public virtual void OnUpdateAction(TSource source, TTarget target)
        {
        }

        public virtual void OnRemoveAction(TTarget target)
        {
        }
    }

    public class SomeRandomClass
    {
        public string String { get; set; }
    }

    public class SomeRandomClassEqualsCaseInsensitiveString : SomeRandomClass
    {
        public override bool Equals(object obj)
        {
            if (obj is SomeRandomClass casted)
            {
                var result = Equals(casted);
                return result;
            }
            else
            {
                var result = ReferenceEquals(this, obj);
                return result;
            }
        }

        private bool Equals(SomeRandomClass other)
        {
            var result = string.Equals(String, other.String, StringComparison.CurrentCultureIgnoreCase);
            return result;
        }

        public override int GetHashCode()
        {
            return String != null ? String.GetHashCode() : 0;
        }
    }

    public class BaseClass
    {
    }

    public class ChildClass : BaseClass
    {
    }

    #endregion
}
