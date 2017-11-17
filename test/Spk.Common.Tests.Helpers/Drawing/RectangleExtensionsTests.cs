#if NET45
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
        public void Merge_ShouldMergeSeperateRectangles_WhenPositionDiffers()
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
                }
            }.Merge();

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void Merge_ShouldMergeWithoutRecursion_WhenLargeGrid()
        {
            var result = new List<Rectangle>
            {
                new Rectangle(2587, 1467, 5, 9),
                new Rectangle(994, 1196, 77, 19),
                new Rectangle(1003, 1047, 12, 18),
                new Rectangle(997, 1002, 9, 9),
                new Rectangle(1133, 995, 13, 14),
                new Rectangle(1045, 981, 30, 23),
                new Rectangle(1131, 975, 11, 10),
                new Rectangle(1091, 968, 29, 26),
                new Rectangle(1002, 956, 19, 14),
                new Rectangle(1022, 943, 12, 13),
                new Rectangle(1088, 942, 14, 29),
                new Rectangle(2453, 932, 13, 128),
                new Rectangle(1080, 931, 9, 9),
                new Rectangle(1035, 929, 10, 11),
                new Rectangle(2222, 905, 35, 15),
                new Rectangle(2426, 904, 36, 21),
                new Rectangle(2165, 826, 23, 19),
                new Rectangle(883, 815, 27, 37),
                new Rectangle(2418, 810, 43, 88),
                new Rectangle(2515, 809, 72, 54),
                new Rectangle(891, 733, 24, 54),
                new Rectangle(2351, 729, 10, 11),
                new Rectangle(2295, 728, 26, 13),
                new Rectangle(1085, 709, 10, 10),
                new Rectangle(1066, 698, 9, 10),
                new Rectangle(1027, 689, 17, 12),
                new Rectangle(1020, 672, 11, 14),
                new Rectangle(1050, 670, 9, 9),
                new Rectangle(1123, 663, 14, 11),
                new Rectangle(997, 649, 15, 29),
                new Rectangle(1036, 640, 12, 24),
                new Rectangle(1080, 639, 13, 22),
                new Rectangle(881, 622, 21, 33),
                new Rectangle(1038, 616, 20, 24),
                new Rectangle(885, 594, 12, 11),
                new Rectangle(997, 376, 452, 734),
                new Rectangle(992, 372, 178, 325),
                new Rectangle(1250, 362, 203, 12),
                new Rectangle(1135, 362, 30, 9),
                new Rectangle(993, 360, 10, 9),
                new Rectangle(992, 337, 13, 10),
                new Rectangle(1220, 323, 235, 33),
                new Rectangle(991, 320, 206, 29)
            }.Merge();

            Assert.Equal(19, result.Length);
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
    }
}
#endif
