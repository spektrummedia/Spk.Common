using System.Collections.Generic;
using Shouldly;
using Spk.Common.Helpers.Collection;
using Xunit;

namespace Spk.Common.Tests.Helpers.Collections
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void SynchronizeWith_ShouldAddMissingItems()
        {
            var target = new List<int>
            {
                1,
                3,
                5,
                7,
                9
            };
            var source = new List<int>
            {
                9,
                2,
                4,
                6,
                8
            };

            target.SynchronizeWith(source);

            target.SynchronizeWith(source.AsReadOnly());

            target.ShouldContain(9);
            target.ShouldContain(2);
            target.ShouldContain(4);
            target.ShouldContain(6);
            target.ShouldContain(8);

            target.ShouldNotContain(1);
            target.ShouldNotContain(3);
            target.ShouldNotContain(5);
            target.ShouldNotContain(7);
        }
    }
}
