using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        public class GuardIsWithinRange_double
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            [InlineData(-1, -1.89, 0.93)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                double argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            [InlineData(-1, -0.89, 1.5)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                double argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_float
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            [InlineData(-1, -1.89, 0.93)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                float argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            [InlineData(-1, -0.89, 1.5)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                float argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_decimal
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            [InlineData(-1, -1.89, 0.93)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                decimal argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            [InlineData(-1, -0.89, 1.5)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                decimal argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_short
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            [InlineData(-1, -1.89, 0.93)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                short argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            [InlineData(-1, -0.89, 1.5)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                short argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_int
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            [InlineData(-1, -1.89, 0.93)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                int argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            [InlineData(-1, -0.89, 1.5)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                int argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_long
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            [InlineData(-1, -1.89, 0.93)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                long argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            [InlineData(-1, -0.89, 1.5)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                long argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_ushort
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                ushort argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                ushort argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }
        }

        public class GuardIsWithinRange_uint
        {
            [Theory]
            [InlineData(2, 1, 3)]
            [InlineData(2, 1, 2)]
            [InlineData(2, 2, 3)]
            [InlineData(2, 1.89, 2.03)]
            public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                uint argument,
                double lowerBound,
                double upperBound)
            {
                var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                result.ShouldBe(argument);
            }

            [Theory]
            [InlineData(0, 1, 3)]
            [InlineData(3, 1, 2)]
            public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                uint argument,
                double lowerBound,
                double upperBound)

            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    nameof(argument), 
                    () =>
                    {
                        argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    });
            }

            public class GuardIsWithinRange_ulong
            {
                [Theory]
                [InlineData(2, 1, 3)]
                [InlineData(2, 1, 2)]
                [InlineData(2, 2, 3)]
                [InlineData(2, 1.89, 2.03)]
                public void GuardIsWithinRange_ShouldReturnUnalteredValue_WhenArgumentIsWithinRange(
                    ulong argument,
                    double lowerBound,
                    double upperBound)
                {
                    var result = argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                    result.ShouldBe(argument);
                }

                [Theory]
                [InlineData(0, 1, 3)]
                [InlineData(3, 1, 2)]
                public void GuardIsWithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
                    ulong argument,
                    double lowerBound,
                    double upperBound)

                {
                    Assert.Throws<ArgumentOutOfRangeException>(
                        nameof(argument), 
                        () =>
                        {
                            argument.GuardIsWithinRange(lowerBound, upperBound, nameof(argument));
                        });
                }
            }
        }
    }
}