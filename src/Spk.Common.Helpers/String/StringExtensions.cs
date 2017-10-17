using System;
using System.Net;

namespace Spk.Common.Helpers.String
{
    public static class StringExtensions
    {
        /// <summary>
        /// Answer true if this string is either null or empty.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        /// Answer true if this string is either null or empty.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public static bool HasValue(this string s) => !IsNullOrEmpty(s);

        /// <summary>
        /// Encodes the string as HTML
        /// </summary>
        /// <param name="s">The dangerous string to encode</param>
        /// <returns></returns>
        public static string HtmlEncode(this string s) => s.HasValue() ? WebUtility.HtmlEncode(s) : s;

        /// <summary>
        /// Decodes an HTML string.
        /// </summary>
        /// <param name="s">The HTML-encoded string to decode.</param>
        /// <returns></returns>
        public static string HtmlDecode(this string s) => s.HasValue() ? WebUtility.HtmlDecode(s) : s;

        /// <summary>
        /// Encodes the string for URLs.
        /// </summary>
        /// <param name="s">The string to encode</param>
        /// <returns></returns>
        public static string UrlEncode(this string s) => s.HasValue() ? WebUtility.UrlEncode(s) : s;

        /// <summary>
        /// Decodes an URL-encoded string.
        /// </summary>
        /// <param name="s">The URL-encoded string to decode.</param>
        /// <returns></returns>
        public static string UrlDecode(this string s) => s.HasValue() ? WebUtility.UrlDecode(s) : s;

        /// <summary>
        /// Convert a string to integer using the Convert.ToInt32 method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static int ToInt32(this string s) => Convert.ToInt32(s);

        /// <summary>
        /// Convert a string to float using the Convert.ToSingle method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static float ToFloat(this string s) => Convert.ToSingle(s);

        /// <summary>
        /// Convert a string to decimal using the Convert.ToDecimal method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s) => Convert.ToDecimal(s);

        /// <summary>
        /// Convert a string to boolean using the Convert.ToBoolean method.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns></returns>
        public static bool ToBoolean(this string s) => Convert.ToBoolean(s);
    }
}