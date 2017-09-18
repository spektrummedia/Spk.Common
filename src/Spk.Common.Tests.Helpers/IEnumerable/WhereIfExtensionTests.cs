using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spk.Common.Helpers.IEnumerable;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class WhereIfExtensionTests
    {
        [Test]
        public void WhereIf_ShouldReturn_WhenConditionIsFalse()
        {
            var data = new List<string> {"test", "data", "halleyhop", "blabla"};
            var result = data.WhereIf(false, x => x.Equals("data"));

            Assert.That(result.Count(), Is.EqualTo(4));
            Assert.IsTrue(Equals(result, data));
        }

        [Test]
        public void WhereIf_ShouldReturn_WhenConditionIsTrue()
        {
            var data = new List<string> {"test", "data", "halleyhop", "blabla"};
            var result = data.WhereIf(data.Count == 4, x => x.Equals("test"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo("test"));
        }

        [Test]
        public void WhereIf_ShouldReturnNull_WhenSourceIsNull()
        {
            List<string> data = null;
            var result = data.WhereIf(true, x => x.Equals("data"));
            Assert.IsNull(result);
        }
    }
}