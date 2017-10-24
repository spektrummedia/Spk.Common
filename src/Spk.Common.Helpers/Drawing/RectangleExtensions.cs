#if NET452
using System.Collections.Generic;
using System.Drawing;

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

            foreach (var rect in rectangles)
            {
                var matched = false;
                for (var i = 0; i < clusters.Count; i++)
                {
                    if (rect.IntersectsWith(clusters[i]))
                    {
                        matched = true;
                        clusters.Add(Rectangle.Union(clusters[i], rect));
                        clusters.RemoveAt(i);
                    }
                }

                if (!matched)
                {
                    clusters.Add(rect);
                }
            }

            return clusters.ToArray();
        }
    }
}
#endif
