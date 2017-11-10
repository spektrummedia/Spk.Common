using System;
using System.Collections.Generic;
using System.Linq;

namespace Spk.Common.Helpers.Enum
{
    public static class Util
    {
        /// <summary>
        /// Given an enumerator, return a List of Tuple with
        /// the values of the enumerator and his description
        /// </summary>
        /// <typeparam name="T">enum</typeparam>
        /// <returns>List of Tuple </returns>
        public static List<Tuple<int, string>> EnumToListTuple<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return System.Enum.GetValues(typeof(T)).Cast<T>()
                .Select(e => Tuple.Create(
                    ((int)(object)e), (e as System.Enum).GetDescription())).ToList();
        }
    }
}
