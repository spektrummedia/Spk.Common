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
        /// Answer true if this string is either null or white spaces only.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string s) => string.IsNullOrWhiteSpace(s);

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
    }
}