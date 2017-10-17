using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace Spk.Common.Helpers.String
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Answer true if this string is either null or empty.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        ///     Answer true if this string is either null or empty.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public static bool HasValue(this string s)
        {
            return !IsNullOrEmpty(s);
        }

        /// <summary>
        ///     Encodes the string as HTML
        /// </summary>
        /// <param name="s">The dangerous string to encode</param>
        /// <returns></returns>
        public static string HtmlEncode(this string s)
        {
            return s.HasValue() ? WebUtility.HtmlEncode(s) : s;
        }

        /// <summary>
        ///     Decodes an HTML string.
        /// </summary>
        /// <param name="s">The HTML-encoded string to decode.</param>
        /// <returns></returns>
        public static string HtmlDecode(this string s)
        {
            return s.HasValue() ? WebUtility.HtmlDecode(s) : s;
        }

        /// <summary>
        ///     Encodes the string for URLs.
        /// </summary>
        /// <param name="s">The string to encode</param>
        /// <returns></returns>
        public static string UrlEncode(this string s)
        {
            return s.HasValue() ? WebUtility.UrlEncode(s) : s;
        }

        /// <summary>
        ///     Decodes an URL-encoded string.
        /// </summary>
        /// <param name="s">The URL-encoded string to decode.</param>
        /// <returns></returns>
        public static string UrlDecode(this string s)
        {
            return s.HasValue() ? WebUtility.UrlDecode(s) : s;
        }

        /// <summary>
        ///     Convert a string to integer using the Convert.ToInt32 method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static int ToInt32(this string s)
        {
            return Convert.ToInt32(s);
        }

        /// <summary>
        ///     Convert a string to float using the Convert.ToSingle method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static float ToFloat(this string s)
        {
            return Convert.ToSingle(s);
        }

        /// <summary>
        ///     Convert a string to decimal using the Convert.ToDecimal method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            return Convert.ToDecimal(s);
        }

        /// <summary>
        ///     Convert a string to boolean using the Convert.ToBoolean method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static bool ToBoolean(this string s)
        {
            return Convert.ToBoolean(s);
        }

        /// <summary>
        ///     Remove accents from a string.
        /// </summary>
        /// <param name="s">The string to process.</param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}