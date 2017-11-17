namespace Spk.Common.Helpers.Enum
{
    using System;   
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        /// <summary>
        /// Return the "Description" attribute from an enumerator
        /// </summary>
        /// <param name="element">enumerator</param>
        /// <returns>the corresponding "description" attribute from the enumerator</returns>
        public static string GetDescription(this Enum element)
        {
            var type = element.GetType();

            var memberInfo = type.GetMember(element.ToString());

            if (memberInfo.Length <= 0) return element.ToString();

            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? ((DescriptionAttribute)attributes[0]).Description
                : element.ToString();
        }
    }
}
