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
        /// <param name="chunkSize">The maximal size of each chunk</param>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            source.GuardIsNotNull(nameof(source));
            chunkSize.GuardIsGreaterThan(0, nameof(chunkSize));

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
