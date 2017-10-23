using System;
using System.Text.RegularExpressions;
using Spk.Common.Helpers.String;

namespace Spk.Common.Helpers.Guard
{
    /// <summary>
    /// Guard methods that perform various validation against method arguments
    /// </summary>
    public static class ArgumentGuard
    {
        #region GuardIsWithinRange

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static double GuardIsWithinRange(
            this double argument,
            double lower,
            double upper,
            string paramName)
        {
            if (argument < lower || argument > upper)
            {
                throw new ArgumentOutOfRangeException(paramName,
                    $"Must be in the following range : {lower} to {upper}");
            }
            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static float GuardIsWithinRange(
            this float argument,
            double lower,
            double upper,
            string paramName)
        {
            return (float)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static decimal GuardIsWithinRange(
            this decimal argument,
            double lower,
            double upper,
            string paramName)
        {
            return (decimal)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static short GuardIsWithinRange(
            this short argument,
            double lower,
            double upper,
            string paramName)
        {
            return (short)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static int GuardIsWithinRange(
            this int argument,
            double lower,
            double upper,
            string paramName)
        {
            return (int)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static long GuardIsWithinRange(
            this long argument,
            double lower,
            double upper,
            string paramName)
        {
            return (long)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ushort GuardIsWithinRange(
            this ushort argument,
            double lower,
            double upper,
            string paramName)
        {
            return (ushort)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static uint GuardIsWithinRange(
            this uint argument,
            double lower,
            double upper,
            string paramName)
        {
            return (uint)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is within range from <paramref name="lower"/> to <paramref name="upper"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="lower">The lower bound of the test</param>
        /// <param name="upper">The upper bound of the test</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <remarks>The test on <paramref name="lower"/> and <paramref name="upper"/> is inclusive.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ulong GuardIsWithinRange(
            this ulong argument,
            double lower,
            double upper,
            string paramName)
        {
            return (ulong)((double)argument).GuardIsWithinRange(lower, upper, paramName);
        }

        #endregion

        #region GuardIsGreaterThan

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static double GuardIsGreaterThan(
            this double argument,
            double target,
            string paramName)
        {
            if (argument <= target)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be greater than {target}");
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static float GuardIsGreaterThan(
            this float argument,
            double target,
            string paramName)
        {
            return (float)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static decimal GuardIsGreaterThan(
            this decimal argument,
            double target,
            string paramName)
        {
            return (decimal)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static short GuardIsGreaterThan(
            this short argument,
            double target,
            string paramName)
        {
            return (short)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static int GuardIsGreaterThan(
            this int argument,
            double target,
            string paramName)
        {
            return (int)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static long GuardIsGreaterThan(
            this long argument,
            double target,
            string paramName)
        {
            return (long)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ushort GuardIsGreaterThan(
            this ushort argument,
            double target,
            string paramName)
        {
            return (ushort)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static uint GuardIsGreaterThan(
            this uint argument,
            double target,
            string paramName)
        {
            return (uint)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ulong GuardIsGreaterThan(
            this ulong argument,
            double target,
            string paramName)
        {
            return (ulong)((double)argument).GuardIsGreaterThan(target, paramName);
        }

        #endregion

        #region GuardIsGreaterThanOrEqualTo

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static double GuardIsGreaterThanOrEqualTo(
            this double argument,
            double target,
            string paramName)
        {
            if (argument < target)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be greater than or equal to {target}");
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static float GuardIsGreaterThanOrEqualTo(
            this float argument,
            double target,
            string paramName)
        {
            return (float)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static decimal GuardIsGreaterThanOrEqualTo(
            this decimal argument,
            double target,
            string paramName)
        {
            return (decimal)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static short GuardIsGreaterThanOrEqualTo(
            this short argument,
            double target,
            string paramName)
        {
            return (short)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static int GuardIsGreaterThanOrEqualTo(
            this int argument,
            double target,
            string paramName)
        {
            return (int)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static long GuardIsGreaterThanOrEqualTo(
            this long argument,
            double target,
            string paramName)
        {
            return (long)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ushort GuardIsGreaterThanOrEqualTo(
            this ushort argument,
            double target,
            string paramName)
        {
            return (ushort)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static uint GuardIsGreaterThanOrEqualTo(
            this uint argument,
            double target,
            string paramName)
        {
            return (uint)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is greater or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ulong GuardIsGreaterThanOrEqualTo(
            this ulong argument,
            double target,
            string paramName)
        {
            return (ulong)((double)argument).GuardIsGreaterThanOrEqualTo(target, paramName);
        }

        #endregion

        #region GuardIsLessThan

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static double GuardIsLessThan(
            this double argument,
            double target,
            string paramName)
        {
            if (argument >= target)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be less than {target}");
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static float GuardIsLessThan(
            this float argument,
            double target,
            string paramName)
        {
            return (float)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static decimal GuardIsLessThan(
            this decimal argument,
            double target,
            string paramName)
        {
            return (decimal)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static short GuardIsLessThan(
            this short argument,
            double target,
            string paramName)
        {
            return (short)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static int GuardIsLessThan(
            this int argument,
            double target,
            string paramName)
        {
            return (int)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static long GuardIsLessThan(
            this long argument,
            double target,
            string paramName)
        {
            return (long)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ushort GuardIsLessThan(
            this ushort argument,
            double target,
            string paramName)
        {
            return (ushort)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static uint GuardIsLessThan(
            this uint argument,
            double target,
            string paramName)
        {
            return (uint)((double)argument).GuardIsLessThan(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less than <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ulong GuardIsLessThan(
            this ulong argument,
            double target,
            string paramName)
        {
            return (ulong)((double)argument).GuardIsLessThan(target, paramName);
        }

        #endregion

        #region GuardIsLessThanOrEqualTo

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static double GuardIsLessThanOrEqualTo(
            this double argument,
            double target,
            string paramName)
        {
            if (argument > target)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be greater than or equal to {target}");
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static float GuardIsLessThanOrEqualTo(
            this float argument,
            double target,
            string paramName)
        {
            return (float)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static decimal GuardIsLessThanOrEqualTo(
            this decimal argument,
            double target,
            string paramName)
        {
            return (decimal)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static short GuardIsLessThanOrEqualTo(
            this short argument,
            double target,
            string paramName)
        {
            return (short)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static int GuardIsLessThanOrEqualTo(
            this int argument,
            double target,
            string paramName)
        {
            return (int)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static long GuardIsLessThanOrEqualTo(
            this long argument,
            double target,
            string paramName)
        {
            return (long)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ushort GuardIsLessThanOrEqualTo(
            this ushort argument,
            double target,
            string paramName)
        {
            return (ushort)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static uint GuardIsLessThanOrEqualTo(
            this uint argument,
            double target,
            string paramName)
        {
            return (uint)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> is less or equals to <paramref name="target"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The target that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static ulong GuardIsLessThanOrEqualTo(
            this ulong argument,
            double target,
            string paramName)
        {
            return (ulong)((double)argument).GuardIsLessThanOrEqualTo(target, paramName);
        }

        #endregion

        /// <summary>
        /// Guards that <paramref name="argument"/> matches <paramref name="regex"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="regex">The regular expression that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when throwing <exception cref="ArgumentException"></exception></param>
        /// <exception cref="ArgumentException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static string GuardMatchesRegex(
            this string argument,
            Regex regex,
            string paramName)
        {
            regex.GuardIsNotNull(nameof(regex));

            if (!regex.IsMatch(argument))
            {
                throw new ArgumentException($"Must match '{regex}'", paramName);
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> matches <paramref name="regex"/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="regex">The regex expression that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when throwing <exception cref="ArgumentException"></exception></param>
        /// <exception cref="ArgumentException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static string GuardMatchesRegex(
            this string argument,
            string regex,
            string paramName)
        {
            regex.GuardIsNotNull(nameof(regex));

            return argument.GuardMatchesRegex(new Regex(regex), paramName);
        }


        /// <summary>
        /// Guards that <paramref name="argument"/> date is later than <paramref name="target" /> date
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The date that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static System.DateTime GuardIsLaterThan(
            this System.DateTime argument,
            System.DateTime target,
            string paramName)
        {
            if (argument <= target)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be later than {target}");
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> date is earlier than <paramref name="target" /> date/>
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="target">The date that <paramref name="argument"/> validates against</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static System.DateTime GuardIsEarlierThan(
            this System.DateTime argument,
            System.DateTime target,
            string paramName)
        {
            if (argument >= target)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be ealier than {target}");
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> string is not null or all white spaces
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentOutOfRangeException">throwing</exception></param>
        /// <exception cref="ArgumentOutOfRangeException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static string GuardIsNotNullOrWhiteSpace(
            this string argument,
            string paramName)
        {
            if (argument.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Must not be null or contain only white spaces", paramName);
            }

            return argument;
        }

        /// <summary>
        /// Guards that <paramref name="argument"/> not null
        /// </summary>
        /// <param name="argument">the argument being guarded</param>
        /// <param name="paramName">the name of the param beign tested. This is used when <exception cref="ArgumentNullException">throwing</exception></param>
        /// <exception cref="ArgumentNullException">When test fails</exception>
        /// <returns>Returns <paramref name="argument"/> as is, when the test succeeds</returns>
        public static T GuardIsNotNull<T>(
            this T argument,
            string paramName)
        {
            if (ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(paramName, "Must not be null");
            }

            return argument;
        }
    }
}
