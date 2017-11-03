using BenchmarkDotNet.Running;
using Spk.Common.Benchmarks.Helpers.IEnumerable;

namespace Spk.Common.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ShuffleExtensionBenchmarks>();
        }
    }
}
