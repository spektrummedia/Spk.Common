using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class WhereIfExtensionTests
    {
        [Fact]
        public void WhereIf_ShouldReturn_WhenConditionIsFalse()
        {
            var data = new List<string> {"test", "data", "halleyhop", "blabla"};
            var result = data.WhereIf(false, x => x.Equals("data"));

            Assert.Equal(4, result.Count());
            Assert.True(Equals(result, data));
        }

        [Fact]
        public void WhereIf_ShouldReturn_WhenConditionIsTrue()
        {
            var data = new List<string> {"test", "data", "halleyhop", "blabla"};
            var result = data.WhereIf(data.Count == 4, x => x.Equals("test"));
            Assert.Single(result);
            Assert.Equal("test", result.First());
        }

        [Fact]
        public void WhereIf_ShouldReturnNull_WhenSourceIsNull()
        {
            List<string> data = null;
            var result = data.WhereIf(true, x => x.Equals("data"));
            Assert.Null(result);
        }
    }
}