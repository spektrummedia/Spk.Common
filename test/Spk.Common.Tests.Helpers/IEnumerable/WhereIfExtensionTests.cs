using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class WhereIfExtensionTests
    {
        [InlineData(true)]
        [InlineData(false)]
        [Theory]
        public void WhereIf_ShouldReturn_WhenConditionIsFalse(bool isQueryable)
        {
            // Arrange
            List<string> data = new List<string>
            {
                "test",
                "data",
                "halleyhop",
                "blabla"
            };

            // Act
            IEnumerable<string> result = isQueryable
                ? data.AsQueryable().WhereIf(false, x => x.Equals("data"))
                : data.WhereIf(false, x => x.Equals("data"));

            // Assert
            Assert.Equal(4, result.Count());
            Assert.True(result.SequenceEqual(data));
        }

        [InlineData(true)]
        [InlineData(false)]
        [Theory]
        public void WhereIf_ShouldReturn_WhenConditionIsTrue(bool isQueryable)
        {
            // Arrange
            List<string> data = new List<string>
            {
                "test",
                "data",
                "halleyhop",
                "blabla"
            };

            // Act
            IEnumerable<string> result = isQueryable
                ? data.AsQueryable().WhereIf(data.Count == 4, x => x.Equals("test"))
                : data.WhereIf(data.Count == 4, x => x.Equals("test"));

            // Assert
            Assert.Single(result);
            Assert.Equal("test", result.First());
        }

        [Fact]
        public void WhereIf_ShouldReturnNull_WhenIEnumerableSourceIsNull()
        {
            List<string> data = null;
            Assert.Null(data.WhereIf(true, x => x.Equals("data")));
        }

        [Fact]
        public void WhereIf_ShouldReturnNull_WhenIQueryableSourceIsNull()
        {
            IQueryable<string> data = null;
            Assert.Null(data.WhereIf(true, x => x.Equals("data")));
        }
    }
}
