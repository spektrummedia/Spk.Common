using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Random;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class ShuffleExtension
    {
        /// <summary>
        ///     Randomize an IEnumerable collection
        ///     https://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
        /// </summary>
        /// <typeparam name="T">Type of the items in the collections</typeparam>
        /// <param name="elements">The source collection.</param>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> elements)
        {
            var arrayOfElement = elements.ToArray();
            for (var i = arrayOfElement.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                var swapIndex = ThreadSafeRandom.Random.Next(i + 1);
                yield return arrayOfElement[swapIndex];
                arrayOfElement[swapIndex] = arrayOfElement[i];
            }
        }
    }
}
