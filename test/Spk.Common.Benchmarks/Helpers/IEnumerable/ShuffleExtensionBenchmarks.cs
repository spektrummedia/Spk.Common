using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Spk.Common.Helpers.IEnumerable;

namespace Spk.Common.Benchmarks.Helpers.IEnumerable
{
    public class ShuffleExtensionBenchmarks
    {
        [Benchmark]
        public IEnumerable<int> Shuffle_Benchmark()
        {
            return Enumerable.Range(1, 100000).Shuffle();
        }
    }
}
