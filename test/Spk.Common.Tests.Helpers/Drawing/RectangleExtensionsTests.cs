#if NET452
using System.Collections.Generic;
using System.Drawing;
using Spk.Common.Helpers.Drawing;
using Xunit;

namespace Spk.Common.Tests.Helpers.Drawing
{
    public class RectangleExtensionsTests
    {
        [Fact]
        public void Merge_ShouldMergeRectanglesAsOne_WhenAtSamePositionButNotSameSize()
        {
            var result = new List<Rectangle>
            {
                new Rectangle(0, 0, 20, 20),
                new Rectangle(0, 0, 40, 20)
            }.Merge();

            Assert.Single(result);
            Assert.Equal(40, result[0].Width);
        }

        [Fact]
        public void Merge_ShouldMergeRectanglesAsOne_WhenExactlyEqual()
        {
            var result = new List<Rectangle>
            {
                new Rectangle(0, 0, 20, 20),
                new Rectangle(0, 0, 20, 20)
            }.Merge();
            Assert.Single(result);
            Assert.Equal(20, result[0].Height);
            Assert.Equal(20, result[0].Width);
        }

        [Fact]
        public void Merge_ShouldMergeSeperateRectangles()
        {
            var result = new List<Rectangle>
            {
                new Rectangle(100, 0, 20, 20),
                new Rectangle(100, 0, 20, 40),

                new Rectangle(50, 0, 20, 20),

                new Rectangle(0, 0, 20, 20),
                new Rectangle(0, 0, 20, 20)
            }.Merge();

            Assert.Equal(3, result.Length);
        }

        [Fact]
        public void Merge_ShouldNotMergeRectangles_WhenTwoDifferent()
        {
            var result = new List<Rectangle>
            {
                new Rectangle(50, 0, 20, 20),
                new Rectangle(0, 0, 40, 20)
            }.Merge();

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void Merge_ShouldNotMergeSeperateRectangles()
        {
            var result = new List<Rectangle>
            {
                new Rectangle
                {
                    X = 997,
                    Y = 376,
                    Width = 452,
                    Height = 734
                },
                new Rectangle
                {
                    X = 1088,
                    Y = 942,
                    Width = 32,
                    Height = 52
                },

                new Rectangle
                {
                    X = 992,
                    Y = 372,
                    Width = 178,
                    Height = 329
                },

                new Rectangle
                {
                    X = 991,
                    Y = 320,
                    Width = 206,
                    Height = 29
                },
            }.Merge();

            Assert.Equal(2, result.Length);
        }
    }
}
#endif
