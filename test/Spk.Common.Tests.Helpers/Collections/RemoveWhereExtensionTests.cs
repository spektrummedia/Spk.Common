using System;
using System.Collections.Generic;
using Spk.Common.Helpers.Collection;
using Xunit;

namespace Spk.Common.Tests.Helpers.Collections
{
    public class RemoveWhereExtensionTests
    {
        private readonly List<string> _data;

        public RemoveWhereExtensionTests()
        {
            _data = new List<string> {"pomme", "fraise", "raisin", "banane"};
        }

        [Fact]
        public void RemoveWhere_ShouldThrows_WhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ((List<string>)null).RemoveWhere(x => true);
            });
        }

        [Fact]
        public void RemoveWhere_ShouldNotRemoveAnyItems_WhenPredicateIsFalse()
        {
            // Act
            var result = _data.RemoveWhere(x => x == "orange");

            // Assert
            Assert.Equal(_data.Count, result.Count);
            Assert.DoesNotContain("orange", _data);
        }

        [Fact]
        public void RemoveWhere_ShouldRemoveAllElementsThatMatchesThePredicate()
        {
            // Act
            var result = _data.RemoveWhere(x => x == "fraise" || x == "banane");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.DoesNotContain("fraise", _data);
            Assert.DoesNotContain("banane", _data);
        }

        [Fact]
        public void RemoveWhere_ShouldRemoveOneElement_WhenPredicateMatchesOneElement()
        {
            // Act
            var result = _data.RemoveWhere(x => x == "fraise");

            // Assert
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain("fraise", _data);
        }

        [Fact]
        public void RemoveWhere_ShouldReturn_WhenSourceIsEmpty()
        {
            // Arrange
            var data = new List<string>();

            // Act
            var result = data.RemoveWhere(x => x == "fraise" || x == "banane");

            // Assert
            Assert.Equal(0, result.Count);
        }
    }
}
