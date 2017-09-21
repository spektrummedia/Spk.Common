using System;
using Spk.Common.Helpers.String;

namespace Spk.Common.Helpers.Guard
{
    /// <summary>
    /// Guard methods that perform various validation against method arguments
    /// </summary>
    public static class ArgumentGuard
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="paramName"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        public static void WithinRange(double argument, string paramName, double lower, double upper)
        {
            if (argument < lower || argument > upper)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be in the following range : {lower} to {upper}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mustbegreaterthan"></param>
        /// <param name="i"></param>
        /// <param name="paramName"></param>
        public static void GreaterThan(double mustbegreaterthan, double i, string paramName)
        {
            if (i <= mustbegreaterthan)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be greater than {mustbegreaterthan}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mustbegreaterthan"></param>
        /// <param name="i"></param>
        /// <param name="paramName"></param>
        public static void GreaterThanOrEqualTo(double mustbegreaterthan, double i, string paramName)
        {
            if (i < mustbegreaterthan)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be greater than or equal to {mustbegreaterthan}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mustbelaterthan"></param>
        /// <param name="i"></param>
        /// <param name="paramName"></param>
        public static void LaterThan(System.DateTime mustbelaterthan, System.DateTime i, string paramName)
        {
            if (i <= mustbelaterthan)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Must be later than {mustbelaterthan}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="paramName"></param>
        public static void NotNullOrWhiteSpace(string param, string paramName)
        {
            if (param.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Must not be null or contain only white spaces", paramName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="paramName"></param>
        public static void NotNull<T>(T param, string paramName)
        {
            if (ReferenceEquals(param, null))
            {
                throw new ArgumentException("Must not be null", paramName);
            }
        }
    }
}
