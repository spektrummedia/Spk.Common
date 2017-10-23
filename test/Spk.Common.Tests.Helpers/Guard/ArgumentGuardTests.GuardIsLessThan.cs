using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        public class GuardIsLessThan_double
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                double argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                double argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_float
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                float argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                float argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_decimal
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                decimal argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                decimal argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_short
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                short argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                short argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_int
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                int argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                int argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_long
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                long argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                long argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_ushort
        {
            [Theory]
            [InlineData(1, 2)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                ushort argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                ushort argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThan_uint
        {
            [Theory]
            [InlineData(1, 2)]
            public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                uint argument,
                double target)
            {
                var result = argument.GuardIsLessThan(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                uint argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThan(target, nameof(argument)); });
            }

            public class GuardIsLessThan_ulong
            {
                [Theory]
                [InlineData(1, 2)]
                public void GuardIsLessThan_ShouldReturnUnalteredValue_WhenArgumentIsLessThanTarget(
                    ulong argument,
                    double target)
                {
                    var result = argument.GuardIsLessThan(target, nameof(argument));
                    result.ShouldBe(argument);
                }

                [Theory]
                [InlineData(2, 1)]
                [InlineData(2, 2)]
                public void GuardIsLessThan_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                    ulong argument,
                    double target)
                {
                    Assert.Throws<ArgumentOutOfRangeException>(
                        nameof(argument),
                        () => { argument.GuardIsLessThan(target, nameof(argument)); });
                }
            }
        }
    }
}
