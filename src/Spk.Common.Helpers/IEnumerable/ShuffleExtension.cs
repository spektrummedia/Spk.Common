using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            return elements.Skip(ThreadSafeRandom.Random.Next(elements.Count()));
        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random Random =>
            Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
    }
}
