using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spk.Common.Helpers.IEnumerable;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class ExtractDuplicatesExtensionTests
    {
        [Test]
        public void
            ExtractDuplicates_ShouldExtractGoodData_WhenDuplicatesFoundForPrimitiveTypes()
        {
            var source = new List<int> {1, 2, 3, 5, 5};
            var results = source.ExtractDuplicates();
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(results.First(), Is.EqualTo(5));
        }
    }
}