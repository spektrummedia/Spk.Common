#if NET45
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Spk.Common.Helpers.Drawing
{
    public static class RectangleExtensions
    {
        /// <summary>
        ///     Merge multiple rectangles in cluster.
        ///     https://stackoverflow.com/questions/33984151/combining-rectangle-square-areas-into-bigger-ones-imshow-python
        /// </summary>
        /// <param name="rectangles">List of rectangles to merge</param>
        /// <returns>Clusters of rectangles</returns>
        public static Rectangle[] Merge(this IEnumerable<Rectangle> rectangles)
        {
            var clusters = new List<Rectangle>();

            foreach (var rect in rectangles.ApplyOrdering())
            {
                IntersectsWithClusters(clusters, rect);
            }

            return clusters.ToArray();
        }

        private static void IntersectsWithClusters(List<Rectangle> clusters, Rectangle rect)
        {
            var matched = false;
            for (var i = 0; i < clusters.Count; i++)
            {
                if (rect.IntersectsWith(clusters[i]))
                {
                    matched = true;
                    clusters[i] = Rectangle.Union(clusters[i], rect);
                }
            }

            if (!matched)
            {
                clusters.Add(rect);
            }
        }

        private static IEnumerable<Rectangle> ApplyOrdering(this IEnumerable<Rectangle> rectangles)
        {
            return rectangles
                .OrderBy(x => x.X)
                .ThenBy(x => x.Y)
                .ThenBy(x => x.Width)
                .ThenBy(x => x.Height);
        }
    }
}
#endif
