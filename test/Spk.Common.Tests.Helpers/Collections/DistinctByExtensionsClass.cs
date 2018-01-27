using System;
using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Collection;
using Xunit;
using Xunit.Sdk;

namespace Spk.Common.Tests.Helpers.Collections
{
    public class DistinctByExtensionsClass
    {
        private Person Person1 { get; set; }
        private Person Person2 { get; set; }
        private Person Person3 { get; set; }
        private Person Person4 { get; set; }

        public DistinctByExtensionsClass()
        {
            Person1 = new Person
            {
                Age = 56,
                IsDead = false,
                LastName = "Bond",
                Name = "James",
                IsApprouved = false
            };

            Person2 = new Person
            {
                Age = 60,
                IsDead = true,
                LastName = "Jackson",
                Name = "Micheal",
                IsApprouved = false
            };

            Person3 = new Person
            {
                Age = 56,
                IsDead = true,
                LastName = "Jackson",
                Name = "Tito",
                IsApprouved = false
            };

            Person4 = new Person
            {
                Age = 62,
                IsDead = false,
                LastName = "Willis",
                Name = "Bruce",
                IsApprouved = true
            };
        }

        [Fact]
        public void DistinctBy_ShouldReturnUniqueValuesAccordingToKeySelector()
        {
            var data = new List<Person>
            {
                Person1, // IsDead: false
                Person2, // IsDead: true
                Person3  // IsDead: true
            };

            var distinctData = data.DistinctBy(x => x.IsDead);

            Assert.Equal(2, distinctData.Count());
        }

        [Fact]
        public void DistinctBy_ShouldReturnAllValues_WhenAllValuesAreUnique()
        {
            var data = new List<Person>
            {
                Person1, // Name: James,
                Person2, // Name: Micheal
                Person3, // Name: Tito
                Person4  // Names: Bruce
            };

            var distinctData = data.DistinctBy(x => x.Name);

            Assert.Equal(4, distinctData.Count());
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldReturnValueThatMatchPredicate()
        {
            var data = new List<Person>
            {
                Person1, // IsDead: false, IsApprouved:false,
                Person4 // IsDead, false, IsApprouved: true
            };

            var distinctData = data.DistinctBy(x => x.IsDead, p => p.IsApprouved);

            Assert.Single(distinctData);
            Assert.True(distinctData.First().IsApprouved);
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldReturnFirstValue_WhenPredicateMatchesNoValues()
        {
            var data = new List<Person>
            {
                Person2, // LastName: Jackson, IsDead: false
                Person3 // LastName: Jackson, IsDead: false
            };

            var distinctData = data.DistinctBy(x => x.LastName, p => !p.IsDead);

            Assert.Single(distinctData);
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
            var data = (List<Person>) null;
            
            Assert.Throws<ArgumentNullException>(() => data.DistinctBy(x => x.Name));
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldThrowNullArgumentException_WhenSourceIsNull()
        {
            var data = (List<Person>) null;

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy(x => x.Name, x => x.IsDead));
        }

        [Fact]
        public void DistinctBy_ShouldThrowNullArgumentException_WhenKeySelectorIsNull()
        {
            var data = new List<Person>();

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy<Person, string>(null));
        }

        [Fact]
        public void DistinctBy_WithPredicate_ShouldThrowNullArgumentException_WhenKeySelectorIsNull()
        {
            var data = new List<Person>();

            Assert.Throws<ArgumentNullException>(() => data.DistinctBy<Person, string>(null, x => x.IsDead));
        }

        public class Person
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public bool IsDead { get; set; }
            public bool IsApprouved { get; set; }
        }
    }
}
