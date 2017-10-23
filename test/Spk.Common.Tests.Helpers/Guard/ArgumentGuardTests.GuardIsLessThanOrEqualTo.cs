using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        public class GuardIsLessThanOrEqualTo_double
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                double argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                double argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_float
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                float argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                float argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_decimal
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                decimal argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                decimal argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_short
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                short argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                short argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_int
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                int argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                int argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_long
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                long argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            [InlineData(-1230, -1231)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                long argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_ushort
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                ushort argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                ushort argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsLessThanOrEqualTo_uint
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(2, 2)]
            public void GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                uint argument,
                double target)
            {
                var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(2, 1)]
            public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                uint argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
            }

            public class GuardIsLessThanOrEqualTo_ulong
            {
                [Theory]
                [InlineData(1, 2)]
                [InlineData(2, 2)]
                public void
                    GuardIsLessThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsLessThanOrEqualToTarget(
                        ulong argument,
                        double target)
                {
                    var result = argument.GuardIsLessThanOrEqualTo(target, nameof(argument));
                    result.ShouldBe(argument);
                }

                [Theory]
                [InlineData(2, 1)]
                public void GuardIsLessThanOrEqualTo_ShouldThrow_WhenArgumentIsNotLessThanTarget(
                    ulong argument,
                    double target)
                {
                    Assert.Throws<ArgumentOutOfRangeException>(
                        nameof(argument),
                        () => { argument.GuardIsLessThanOrEqualTo(target, nameof(argument)); });
                }
            }
        }
    }
}
