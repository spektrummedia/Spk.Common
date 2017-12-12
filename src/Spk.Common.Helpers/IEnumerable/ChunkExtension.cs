using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class ChunkExtension
    {
        /// <summary>
        ///     Break a list of items into chunks of a specific size
        /// </summary>
        /// <typeparam name="T">Type of the items in the collections</typeparam>
        /// <param name="elements">The source collection</param>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            source.GuardIsNotNull(nameof(source));
            chunksize.GuardIsGreaterThan(0, nameof(chunksize));

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunksize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
