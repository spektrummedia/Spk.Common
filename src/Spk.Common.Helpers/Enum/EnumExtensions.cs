using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Spk.Common.Helpers.Enum
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Return the "Description" attribute from an enumerator
        /// </summary>
        /// <param name="element">enumerator</param>
        /// <returns>the corresponding "description" attribute from the enumerator</returns>
        public static string GetDescription(this System.Enum element)
        {
            Type type = element.GetType();

            MemberInfo[] memberInfo = type.GetMember(element.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return element.ToString();
        }
    }
}
