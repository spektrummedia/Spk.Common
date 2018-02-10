using System.ComponentModel;
using Shouldly;
using Spk.Common.Helpers.Enum;
using Xunit;

namespace Spk.Common.Tests.Helpers.Enum
{
    public class EnumExtensionsTest
    {
        private enum Test
        {
            [Description("My first enum")]
            Test1 = 0,
            Test2 = 1
        }

        private enum EmptyEnum
        {
        }

        [Fact]
        public void GetDescription_ShouldReturnDescriptionIsNull_WhenEnumIsEmpty()
        {
            var test = new EmptyEnum();
            test.GetDescription().ShouldBe(string.Empty);
        }

        [Fact]
        public void Should_Get_The_Good_Description_from_Enum()
        {
            Assert.Equal("My first enum", Test.Test1.GetDescription());
            Assert.Equal("Test2", Test.Test2.GetDescription());
        }
    }
}
