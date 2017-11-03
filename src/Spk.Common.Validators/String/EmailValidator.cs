using System.Text.RegularExpressions;

namespace Spk.Common.Validators.String
{
    public static class EmailValidator
    {
        private const string EMAIL_REGEX = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private const int MAX_EMAIL_LENGTH = 254;

        /// <summary>
        ///     Ensures that an input is actually a valid email.
        ///     Handles maximum length.
        ///     Handles "*+*@*.com".
        /// </summary>
        public static bool IsValidEmail(this string input)
        {
            return input.Length <= MAX_EMAIL_LENGTH && Regex.IsMatch(input, EMAIL_REGEX);
        }
    }
}
