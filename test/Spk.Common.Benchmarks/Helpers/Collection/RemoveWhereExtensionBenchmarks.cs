using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Spk.Common.Helpers.Collection;

namespace Spk.Common.Benchmarks.Helpers.Collection
{
    [MemoryDiagnoser]
    public class RemoveWhereExtensionBenchmarks
    {
        private List<string> _source;

        [GlobalSetup]
        public void InitialData()
        {
            _source = new List<string>();
            for (int i = 0; i < 5000; i++)
                _source.Add("value" + i);
        }

        [Benchmark]
        public ICollection<string> RemoveWhere_Optimized()
        {
            return _source.RemoveWhere(x => x.Contains("1"));
        }

        [Benchmark]
        public ICollection<string> RemoveWhere_Initial()
        {
            return _source.RemoveWhereTest(x => x.Contains("1"));
        }
    }
}
