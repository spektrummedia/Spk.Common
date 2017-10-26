using BenchmarkDotNet.Running;
using Spk.Common.Benchmarks.Helpers.IEnumerable;

namespace Spk.Common.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<ShuffleExtensionBenchmarks>();
        }
    }
}
