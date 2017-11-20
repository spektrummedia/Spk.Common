using System.ComponentModel;
using Spk.Common.Helpers.Enum;
using Xunit;

namespace Spk.Common.Tests.Helpers.Enum
{
    public class EnumExtensionsTest
    {
        private enum Test{
            [Description("My first enum")]
            Test1 = 0,
            Test2 = 1
        }

        [Fact]
        public void Should_Get_The_Good_Description_from_Enum()
        {
            Assert.Equal("My first enum", Test.Test1.GetDescription());
            Assert.Equal("Test2", Test.Test2.GetDescription());
        }
    }
}
