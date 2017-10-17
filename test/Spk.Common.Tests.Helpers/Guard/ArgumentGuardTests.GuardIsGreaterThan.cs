using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        public class GuardIsGreaterThan_double
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                double argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                double argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_float
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                float argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                float argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_decimal
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                decimal argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                decimal argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_short
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                short argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                short argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_int
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                int argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                int argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_long
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                long argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                long argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_ushort
        {
            [Theory]
            [InlineData(2, 1)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                ushort argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                ushort argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThan_uint
        {
            [Theory]
            [InlineData(2, 1)]
            public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                uint argument,
                double target)
            {
                var result = argument.GuardIsGreaterThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                uint argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
            }

            public class GuardIsGreaterThan_ulong
            {
                [Theory]
                [InlineData(2, 1)]
                public void GuardIsGreaterThan_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanTarget(
                    ulong argument,
                    double target)
                {
                    var result = argument.GuardIsGreaterThan(target, nameof(argument));
                    result.ShouldBe(argument);
                }

                [Theory]
                [InlineData(1, 2)]
                [InlineData(2, 2)]
                public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                    ulong argument,
                    double target)
                {
                    Assert.Throws<ArgumentOutOfRangeException>(
                        nameof(argument),
                        () => { argument.GuardIsGreaterThan(target, nameof(argument)); });
                }
            }
        }
    }
}