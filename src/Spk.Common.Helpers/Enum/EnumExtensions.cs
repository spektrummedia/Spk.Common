using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Spk.Common.Helpers.Enum
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     Return the "Description" attribute from an enumerator
        /// </summary>
        /// <param name="element">enumerator</param>
        /// <returns>the corresponding "description" attribute from the enumerator</returns>
        public static string GetDescription(this System.Enum element)
        {
            var type = element.GetType();

            var memberInfo = type.GetMember(element.ToString());

            if (memberInfo.Length <= 0) return string.Empty;

            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? ((DescriptionAttribute)attributes[0]).Description
                : element.ToString();
        }

        /// <summary>
        ///     Splits an combined enum value into it's splitted individual values
        /// </summary>
        /// <typeparam name="T">The Enum Type (must be Enum)</typeparam>
        /// <param name="value">The value to split</param>
        /// <returns>A collection of all values included in the original value</returns>
        public static IEnumerable<T> SplitFlagsEnumValues<T>(this T value)
        {
            var type = EnsureTypeIsFlagsEnum<T>();

            return System.Enum.GetValues(type)
                .Cast<T>()
                .Where(v => (Convert.ToInt32(value) & Convert.ToInt32(v)) != 0)
                .ToList();
        }

        /// <summary>
        ///     Splits an combined enum value into it's splitted individual values
        /// </summary>
        /// <param name="value">The value to split (must be enum)</param>
        /// <returns>A collection of all values included in the original value</returns>
        public static IEnumerable<System.Enum> SplitFlagsEnumValues(this System.Enum value)
        {
            var type = EnsureTypeIsFlagsEnum(value.GetType());

            return System.Enum.GetValues(type)
                .Cast<System.Enum>()
                .Where(v => (Convert.ToInt32(value) & Convert.ToInt32(v)) != 0)
                .ToList();
        }

        /// <summary>
        ///     Aggregates a collection af individual values into a single combined value
        /// </summary>
        /// <typeparam name="T">The enum type (must be Enum)</typeparam>
        /// <param name="values">The values to combine</param>
        /// <returns></returns>
        public static T AggregateFlagsEnumValues<T>(this IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            var type = EnsureTypeIsFlagsEnum<T>();

            return (T)System.Enum.ToObject(type, values.Cast<int>().Distinct().Sum());
        }

        private static Type EnsureTypeIsFlagsEnum<T>()
        {
            return EnsureTypeIsFlagsEnum(typeof(T));
        }

        private static Type EnsureTypeIsFlagsEnum(Type type)
        {
            if (!type.IsEnum && !((type = Nullable.GetUnderlyingType(type))?.IsEnum ?? false))
                throw new ArgumentException("T must be enum type");

            if (!type.GetCustomAttributes(typeof(FlagsAttribute), false).Any())
                throw new InvalidOperationException(
                    $"Enum must have FlagsAttribute in order to call this method");

            return type;
        }
    }
}
