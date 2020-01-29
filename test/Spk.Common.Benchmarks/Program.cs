using BenchmarkDotNet.Running;
using Spk.Common.Benchmarks.Helpers.Collection;

namespace Spk.Common.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<RemoveWhereExtensionBenchmarks>();
        }
    }
}
