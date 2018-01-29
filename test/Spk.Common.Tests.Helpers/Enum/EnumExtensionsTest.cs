using System;
using System.Collections.Generic;
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
            [Description("My first enum")] Test1 = 0,
            Test2 = 1
        }

        [Flags]
        private enum FlagsEnum
        {
            One = 1,

            // ReSharper disable once UnusedMember.Local
            Two = 2,
            Four = 4,
            Eight = 8
        }

        [Fact]
        public void AggregateFlagsEnumValuesT_ShouldSumDistinctValues()
        {
            var result = new List<FlagsEnum>
            {
                FlagsEnum.One,
                FlagsEnum.Four,
                FlagsEnum.Eight,
                FlagsEnum.Four,
                FlagsEnum.One
            }.AggregateFlagsEnumValues();

            result.ShouldBe(FlagsEnum.One | FlagsEnum.Four | FlagsEnum.Eight);
        }

        [Fact]
        public void AggregateFlagsEnumValuesT_ShouldThrow_WhenEnumIsNotEnum()
        {
            Assert.Throws<ArgumentException>(() => new[] {"this is not", "funny"}.AggregateFlagsEnumValues());
        }

        [Fact]
        public void AggregateFlagsEnumValuesT_ShouldThrow_WhenEnumIsNotFlags()
        {
            Assert.Throws<InvalidOperationException>(() => new[] {Test.Test1, Test.Test2}.AggregateFlagsEnumValues());
        }

        [Fact]
        public void Should_Get_The_Good_Description_from_Enum()
        {
            Assert.Equal("My first enum", Test.Test1.GetDescription());
            Assert.Equal("Test2", Test.Test2.GetDescription());
        }

        [Fact]
        public void SplitFlagsEnumValues_ShouldReturnIndividualValuesOfACombinedEnumValue_WhenMultipleValues()
        {
            System.Enum value = FlagsEnum.One | FlagsEnum.Four | FlagsEnum.Eight;

            var result = value.SplitFlagsEnumValues();

            Assert.Collection(result,
                x => x.ShouldBe(FlagsEnum.One),
                x => x.ShouldBe(FlagsEnum.Four),
                x => x.ShouldBe(FlagsEnum.Eight));
        }

        [Fact]
        public void SplitFlagsEnumValues_ShouldReturnIndividualValuesOfACombinedEnumValue_WhenOneValue()
        {
            var value = FlagsEnum.Eight;

            var result = value.SplitFlagsEnumValues();

            Assert.Collection(result, x => x.ShouldBe(FlagsEnum.Eight));
        }

        [Fact]
        public void SplitFlagsEnumValues_ShouldThrow_WhenTypeIsNotEnum()
        {
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
            Assert.Throws<ArgumentException>(() => "I'M NO ENUM".SplitFlagsEnumValues());
        }

        [Fact]
        public void SplitFlagsEnumT_ShouldReturnIndividualValuesOfACombinedEnumValue_WhenMultipleValues()
        {
            var value = FlagsEnum.One | FlagsEnum.Four | FlagsEnum.Eight;

            var result = value.SplitFlagsEnumValues();

            Assert.Collection(result,
                x => x.ShouldBe(FlagsEnum.One),
                x => x.ShouldBe(FlagsEnum.Four),
                x => x.ShouldBe(FlagsEnum.Eight));
        }

        [Fact]
        public void SplitFlagsEnumT_ShouldThrow_WhenEnumIsNotFlags()
        {
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
            Assert.Throws<InvalidOperationException>(() => (Test.Test1 | Test.Test2).SplitFlagsEnumValues());
        }

        [Fact]
        public void SplitFlagsEnumT_ShouldThrow_WhenTypeIsNotEnum()
        {
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
            Assert.Throws<ArgumentException>(() => "I'M NO ENUM".SplitFlagsEnumValues());
        }
    }
}
