using System;

namespace Spk.Common.Helpers.String
{
    public static class UrlValidator
    {
        /// <summary>
        ///     Ensures that an input is actually a valid url.
        ///     Handles HTTP and HTTPS urls.
        ///     The "www" part is optional.
        /// </summary>
        public static bool IsValidUrl(this string input)
        {
            var createdUriIsValid = Uri.TryCreate(input, UriKind.Absolute, out var uriResult);
            return createdUriIsValid && (uriResult.Scheme == Uri.UriSchemeHttp
                                         || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
