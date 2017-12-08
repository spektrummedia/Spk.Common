using System;
using System.ComponentModel;
using System.Linq;
using Spk.Common.Helpers.Enum;
using Xunit;

namespace Spk.Common.Tests.Helpers.Enum
{
    public class EnumUtilTest
    {
        private enum Test
        {
            [Description("My first enum")]
            Test1 = 0,
            Test2 = 1
        }

        [Fact]
        public void Should_Get_List_Of_Tuple_From_Enum()
        {
            var list = EnumUtils.ToTupleList<Test>();

            Assert.Equal(2, list.Count);
            Assert.Equal("Test2", list.First(x => x.Item1 == 1).Item2);
            Assert.Equal("My first enum", list.First(x => x.Item1 == 0).Item2);
        }

        [Fact]
        public void Should_Throw_Exception_From_Not_Enum()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                EnumUtils.ToTupleList<string>();
            });
        }
    }
}
