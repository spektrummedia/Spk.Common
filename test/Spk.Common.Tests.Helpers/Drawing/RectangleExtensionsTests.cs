#if NET45
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Shouldly;
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
            var rectangle = Assert.Single(result);
            Assert.Equal(20, rectangle.Height);
            Assert.Equal(40, rectangle.Width);
            Assert.Equal(0, rectangle.X);
            Assert.Equal(0, rectangle.Y);
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
            var rectangle = Assert.Single(result);
            Assert.Equal(20, rectangle.Height);
            Assert.Equal(20, rectangle.Width);
            Assert.Equal(0, rectangle.X);
            Assert.Equal(0, rectangle.Y);
        }

        [Fact]
        public void Merge_ShouldNotMerge_WhenRectanglesNotStacked()
        {
            // Arrange & act
            var r1 = new Rectangle(50, 0, 20, 20);
            var r2 = new Rectangle(0, 0, 40, 20);
            var result = new List<Rectangle>
                {
                    r1,
                    r2
                }
                .Merge()
                .ToArray();

            // Assert
            Assert.Equal(2, result.Length);

            result.ShouldContain(r => r.Equals(r1));
            result.ShouldContain(r => r.Equals(r2));
        }
    }
}
#endif
