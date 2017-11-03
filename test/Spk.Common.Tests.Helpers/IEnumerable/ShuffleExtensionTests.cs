using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class ShuffleExtensionTests
    {
        private readonly IEnumerable<int> _testCollection = Enumerable.Range(1, 10000);

        [Fact]
        public void Shuffle_ShouldNotAlterTheSizeOfTheEnumerable()
        {
            _testCollection
                .Shuffle()
                .Count()
                .ShouldBe(_testCollection.Count());
        }

        [Fact]
        public void Shuffle_ShouldContainAllElementsFromTheBaseEnumerable()
        {
            var shuffled = _testCollection.Shuffle().ToArray();
            foreach (var item in _testCollection)
            {
                shuffled.ShouldContain(item);
            }
        }

        [Fact]
        public void Shuffle_ShouldNotReturnElementInTheSameOrderAsBaseEnumerable()
        {
            _testCollection.Shuffle()
                .SequenceEqual(_testCollection)
                .ShouldBeFalse();
        }

        // ReSharper disable PossibleMultipleEnumeration
        [Fact]
        public void Shuffle_ShouldReturnDifferentOrderOnEachEnumeration()
        {
            var shuffled = _testCollection.Shuffle();

            shuffled
                .ToArray()
                .SequenceEqual(shuffled.ToArray())
                .ShouldBeFalse();
        }
        // ReSharper restore PossibleMultipleEnumeration

        [Fact]
        public void Shuffle_ShouldAlmostNeverBeEqual()
        {
            for (var i = 0; i < 50; i++)
            {
                Assert.False(_testCollection.SequenceEqual(_testCollection.Shuffle()));
            }
        }
    }
}
