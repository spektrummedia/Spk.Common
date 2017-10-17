using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        public class GuardIsGreaterThanOrEqualTo_double
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                double argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                double argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_float
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                float argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                float argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_decimal
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                decimal argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                decimal argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_short
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                short argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                short argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_int
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                int argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                int argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_long
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            [InlineData(-1230, -1231)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                long argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            [InlineData(-1231, -1230)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                long argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_ushort
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                ushort argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                ushort argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }
        }

        public class GuardIsGreaterThanOrEqualTo_uint
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            public void GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                uint argument,
                double target)
            {
                var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(1, 2)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                uint argument,
                double target)
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument),
                    () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
            }

            public class GuardIsGreaterThanOrEqualTo_ulong
            {
                [Theory]
                [InlineData(2, 1)]
                [InlineData(2, 2)]
                public void
                    GuardIsGreaterThanOrEqualTo_ShouldReturnUnalteredValue_WhenArgumentIsGreaterThanOrEqualToTarget(
                        ulong argument,
                        double target)
                {
                    var result = argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument));
                    result.ShouldBe(argument);
                }

                [Theory]
                [InlineData(1, 2)]
                public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsNotGreaterThanTarget(
                    ulong argument,
                    double target)
                {
                    Assert.Throws<ArgumentOutOfRangeException>(
                        nameof(argument),
                        () => { argument.GuardIsGreaterThanOrEqualTo(target, nameof(argument)); });
                }
            }
        }
    }
}