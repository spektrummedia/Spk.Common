using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class ChunkExtensionTests
    {
        [Theory]
        [InlineData(6, 4, 2)]
        [InlineData(3, 2, 2)]
        [InlineData(6, 2, 3)]
        [InlineData(1, 1, 1)]
        public void Chunk_ShouldDoPartitioning(int count, int chunk, int expectedCount)
        {
            // Arrange
            var list = new List<string>();
            list.AddRange(Enumerable.Repeat("random value", count));

            // Act & assert
            Assert.Equal(expectedCount, list.Chunk(chunk).Count());
        }

        [Fact]
        public void Chunk_ShouldSpreadElementsOverResults()
        {
            // Arrange & act 
            var initialList = new List<string>
            {
                "b",
                "c",
                "a"
            };

            var results = initialList.Chunk(1).ToArray();

            // Assert
            for (var i = 0; i < results.Length; i++)
            {
                Assert.Single(results[i]);
                results[i].ShouldContain(initialList.ElementAt(i));
            }
        }

        [Fact]
        public void Chunk_ShouldThrow_WhenChunkSizeIsNotGreaterThan0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new List<string>().Chunk(0);
            });
        }

        [Fact]
        public void Chunk_ShouldThrow_WhenSourceNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                List<string> list = null;
                list.Chunk(1);
            });
        }
    }
}
