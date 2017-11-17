#if NET45
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Spk.Common.Helpers.Drawing;
using Xunit;

namespace Spk.Common.Tests.Helpers.Drawing
{
    public class RectangleExtensionsTests
    {
        [Fact]
        public void Merge_ShouldMergeMultipleRectangles_WhenClustered()
        {
            // Arrange & act
            var result = new List<Rectangle>
            {
                // cluster #1
                new Rectangle(100, 0, 20, 20),
                new Rectangle(100, 0, 20, 40),

                // cluster #2
                new Rectangle(50, 0, 20, 20),

                // cluster #3
                new Rectangle(0, 0, 20, 20),
                new Rectangle(0, 0, 20, 20)
            }.Merge();

            //  Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Merge_ShouldMergeRectanglesAsOne_WhenAtSamePositionButNotSameSize()
        {
            // Arrange & act
            var result = new List<Rectangle>
            {
                new Rectangle(0, 0, 20, 20),
                new Rectangle(0, 0, 40, 20)
            }.Merge();

            // Assert
            Assert.Single(result);
            Assert.Equal(40, result.ElementAt(0).Width);
        }

        [Fact]
        public void Merge_ShouldMergeRectanglesAsOne_WhenExactlyEqual()
        {
            // Arrange & act
            var result = new List<Rectangle>
            {
                new Rectangle(0, 0, 20, 20),
                new Rectangle(0, 0, 20, 20)
            }.Merge();

            // Assert
            Assert.Single(result);
            Assert.Equal(20, result.ElementAt(0).Height);
            Assert.Equal(20, result.ElementAt(0).Width);
        }

        [Fact]
        public void Merge_ShouldNotMerge_WhenRectanglesNotStacked()
        {
            // Arrange & act
            var result = new List<Rectangle>
            {
                new Rectangle(50, 0, 20, 20),
                new Rectangle(0, 0, 40, 20)
            }.Merge();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
#endif
