using System;
using System.Collections.Generic;

namespace Spk.Common.Helpers.String.Comparers
{
    public class AlphaIntComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            var isFirstStringNumeric = int.TryParse(s1, out var number1);
            var isSecondStringNumeric = int.TryParse(s2, out var number2);

            if (isFirstStringNumeric && isSecondStringNumeric)
            {
                if (number1 > number2)
                {
                    return 1;
                }

                if (number1 < number2)
                {
                    return -1;
                }

                if (number1 == number2)
                {
                    return 0;
                }
            }

            if (isFirstStringNumeric && !isSecondStringNumeric)
            {
                return -1;
            }

            if (!isFirstStringNumeric && isSecondStringNumeric)
            {
                return 1;
            }

            // ReSharper disable once StringCompareIsCultureSpecific.3
            return string.Compare(s1, s2, true);
        }   
    }
}
