using System;
using System.Threading;

namespace Spk.Common.Helpers.Random
{
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static System.Random _local;

        public static System.Random Random => _local ?? (_local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
    }
}