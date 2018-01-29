using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class DistinctByExtensionsTests
    {
        public DistinctByExtensionsTests()
        {
            Person1 = new Person
            {
                Age = 56,
                LovesBeer = false,
                LastName = "Bond",
                Name = "James",
                IsApproved = false
            };

            Person2 = new Person
            {
                Age = 60,
                LovesBeer = true,
                LastName = "Jackson",
                Name = "Michael",
                IsApproved = false
            };

            Person3 = new Person
            {
                Age = 56,
                LovesBeer = true,
                LastName = "Jackson",
                Name = "Tito",
                IsApproved = false
            };

            Person4 = new Person
            {
                Age = 62,
                LovesBeer = false,
                LastName = "Willis",
                Name = "Bruce",
                IsApproved = true
            };
        }

        private Person Person1 { get; }
        private Person Person2 { get; }
        private Person Person3 { get; }
        private Person Person4 { get; }

        public class Person
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public bool LovesBeer { get; set; }
            public bool IsApproved { get; set; }
        }

        [Fact]
        public void DistinctBy_ShouldReturnAllValues_WhenAllValuesAreUnique()
        {
            var data = new List<Person>
            {
                Person1, // Name: James,
                Person2, // Name: Micheal
                Person3, // Name: Tito
                Person4 // Names: Bruce
            };

            var distinctData = data.DistinctBy(x => x.Name);

            Assert.Collection(
                distinctData,
                x => x.ShouldBeSameAs(Person1),
                x => x.ShouldBeSameAs(Person2),
                x => x.ShouldBeSameAs(Person3),
                x => x.ShouldBeSameAs(Person4));
        }

        [Fact]
        public void DistinctBy_ShouldReturnFirstValueOfEachGroupAccordingToKeySelector()
        {
            var data = new List<Person>
            {
                Person1, // IsDead: false
                Person2, // IsDead: true
                Person3 // IsDead: true
            };

            var distinctData = data.DistinctBy(x => x.LovesBeer);

            Assert.Collection(
                distinctData,
                x => x.ShouldBeSameAs(Person1),
                x => x.ShouldBeSameAs(Person2));
        }

        [Fact]
        public void DistinctBy_ShouldThrowNullArgumentException_WhenKeySelectorIsNull()
        {
            var data = new List<Person>();

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy<Person, string>(null));
        }

        [Fact]
        public void DistinctBy_ShouldThrowNullArgumentException_WhenPredicateIsNull()
        {
            var data = new List<Person>();

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy(x => x.Name, null));
        }

        [Fact]
        public void DistinctBy_ShouldThrowNullArgumentException_WhenSourceIsNull()
        {
            var data = (List<Person>)null;

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy(x => x.Name));
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldReturnFirstValue_WhenPredicateMatchesNoValues()
        {
            var data = new List<Person>
            {
                Person2, // LastName: Jackson, LovesBeer: true
                Person3 // LastName: Jackson, LovesBeer: true
            };

            var distinctData = data.DistinctBy(x => x.LastName, p => !p.LovesBeer);

            Assert.Collection(distinctData, x => x.ShouldBeSameAs(Person2));
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldReturnValueThatMatchPredicate()
        {
            var data = new List<Person>
            {
                Person1, // LovesBeer: false, IsApproved: false,
                Person4 // LovesBeer, false, IsApproved: true
            };

            var distinctData = data.DistinctBy(x => x.LovesBeer, p => p.IsApproved);

            Assert.Collection(distinctData, x => x.ShouldBeSameAs(Person4));
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldThrowNullArgumentException_WhenKeySelectorIsNull()
        {
            var data = new List<Person>();

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy<Person, string>(null, x => x.LovesBeer));
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldThrowNullArgumentException_WhenSourceIsNull()
        {
            var data = (List<Person>)null;

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy(x => x.Name, x => x.LovesBeer));
        }
    }
}
