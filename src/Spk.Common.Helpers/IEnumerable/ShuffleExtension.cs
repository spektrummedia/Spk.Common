using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Random;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class ShuffleExtension
    {
        /// <summary>
        ///     Randomize an IEnumerable collection
        /// </summary>
        /// <typeparam name="T">Type of the items in the collections</typeparam>
        /// <param name="elements">The source collection.</param>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> elements)
        {
            return elements.OrderBy(e => ThreadSafeRandom.Random.Next());
        }
    }
}
