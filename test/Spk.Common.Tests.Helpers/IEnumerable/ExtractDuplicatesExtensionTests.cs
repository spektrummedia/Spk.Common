using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class ExtractDuplicatesExtensionTests
    {
        [Fact]
        public void
            ExtractDuplicates_ShouldExtractGoodData_WhenDuplicatesFoundForPrimitiveTypes()
        {
            var source = new List<int> {1, 2, 2, 3, 5, 5, 5};
            var results = source.ExtractDuplicates();
            results.Count().ShouldBe(2);
            results.ShouldContain(2);
            results.ShouldContain(5);
        }
    }
}