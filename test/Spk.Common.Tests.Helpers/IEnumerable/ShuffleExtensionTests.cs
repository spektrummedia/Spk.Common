using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class ShuffleExtensionTests
    {
        private readonly IEnumerable<int> TestCases = Enumerable.Range(1, 10000);

        [Fact]
        public void Shuffle_ShouldAlmostNeverBeEqual()
        {
            for (var i = 0; i < 50; i++)
            {
                Assert.False(TestCases.SequenceEqual(TestCases.Shuffle()));
            }
        }
    }
}
