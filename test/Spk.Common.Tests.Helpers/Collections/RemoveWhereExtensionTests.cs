using System;
using System.Collections.Generic;
using Spk.Common.Helpers.Collection;
using Xunit;

namespace Spk.Common.Tests.Helpers.Collections
{
    public class RemoveWhereExtensionTests
    {
        [Fact]
        public void RemoveWhere_ShouldNotRemoveAnyItems_WhenPredicateIsFalse()
        {
            var data = new List<string>
            {
                "pomme",
                "fraise",
                "raisin",
                "banane"
            };

            var result = data.RemoveWhere(x => x == "orange");

            Assert.Equal(data.Count, result.Count);
            Assert.DoesNotContain("orange", data);
        }

        [Fact]
        public void RemoveWhere_ShouldRemoveAllElementsThatMatchesThePredicate()
        {
            var data = new List<string>
            {
                "pomme",
                "fraise",
                "raisin",
                "banane"
            };

            var result = data.RemoveWhere(x => x == "fraise" || x == "banane");

            Assert.Equal(2, result.Count);
            Assert.DoesNotContain("fraise", data);
            Assert.DoesNotContain("banane", data);
        }

        [Fact]
        public void RemoveWhere_ShouldRemoveOneElement_WhenPredicateMatchesOneElement()
        {
            var data = new List<string>
            {
                "pomme",
                "fraise",
                "raisin",
                "banane"
            };

            var result = data.RemoveWhere(x => x == "fraise");

            Assert.Equal(3, result.Count);
            Assert.DoesNotContain("fraise", data);
        }

        [Fact]
        public void RemoveWhere_ShouldReturn_WhenSourceIsEmpty()
        {
            var data = new List<string>();

            var result = data.RemoveWhere(x => x == "fraise" || x == "banane");

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void RemoveWhere_ShouldThrows_WhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ((List<string>)null).RemoveWhere(x => x != null);
            });
        }
    }
}
