using System.Collections.Generic;
using Shouldly;
using Spk.Common.Helpers.Collection;
using Spk.Common.Tests.Helpers.Collections;
using Xunit;

namespace Spk.Common.Tests.Helpers.Collection
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void SynchronizeWith_OfTypeT_ShouldInvokeAction_WhenConfigIsNotNull()
        {
            var source = new List<string>
            {
                "item #1",
                "item #2"
            };

            var target = new List<string>();
            var actionTrigger = false;

            target.SynchronizeWith(source,
                item => actionTrigger = true);

            target.Count.ShouldBe(2);
            target.ShouldContain(item => item == "item #1");
            target.ShouldContain(item => item == "item #2");
            actionTrigger.ShouldBeTrue();
        }

        [Fact]
        public void SynchronizeWith_WithDifferentType_ShouldInvokeAction_WhenConfigIsNotNull()
        {
            var source = new List<SomeRandomClassEqualsCaseInsensitiveString>
            {
                new SomeRandomClassEqualsCaseInsensitiveString {String = "item #1"},
                new SomeRandomClassEqualsCaseInsensitiveString {String = "item #2"}
            };

            var target = new List<SomeRandomClass>();
            var actionTrigger = false;

            target.SynchronizeWith(source,
                item => actionTrigger = true);

            target.Count.ShouldBe(2);
            target.ShouldContain(item => item.String == "item #1");
            target.ShouldContain(item => item.String == "item #2");
            actionTrigger.ShouldBeTrue();
        }
    }
}
