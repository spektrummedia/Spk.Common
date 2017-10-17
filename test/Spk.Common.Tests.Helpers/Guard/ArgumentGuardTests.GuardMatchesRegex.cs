using System;
using System.Text.RegularExpressions;
using Spk.Common.Helpers.Guard;
using Xunit;

// ReSharper disable InconsistentNaming

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        private const string REGEX = @"(http|https)?:\/\/(www\.)?coub\.com\/view\/([a-zA-Z\d]+)";

        public class GuardMatchesRegex_string
        {
            [Theory]
            [InlineData(REGEX, @"https://coub.com/view/7cwhu")]
            [InlineData(REGEX, @"https://www.coub.com/view/7cwh0")]
            [InlineData(REGEX, @"http://coub.com/view/7cwh0")]
            public void GuardMatchesRegex_ShouldReturnUnalteredArgument_WhenArgumentMatchesRegex(string regex,
                string argument)
            {
                argument.GuardMatchesRegex(regex, nameof(argument));
            }

            [Theory]
            [InlineData(REGEX, @"NONONO")]
            [InlineData(REGEX, @"http://coub/7cwh0")]
            [InlineData(REGEX, @"http://coub.com/foo")]
            public void GuardMatchesRegex_ShouldThrow_WhenArgumentDoesntMatcheRegex(string regex, string argument)
            {
                Assert.Throws<ArgumentException>(nameof(argument),
                    () => { argument.GuardMatchesRegex(regex, nameof(argument)); });
            }
        }

        public class GuardMatchesRegex_regex
        {
            [Theory]
            [InlineData(REGEX, @"https://coub.com/view/7cwhu")]
            [InlineData(REGEX, @"https://www.coub.com/view/7cwh0")]
            [InlineData(REGEX, @"http://coub.com/view/7cwh0")]
            public void GuardMatchesRegex_ShouldReturnUnalteredArgument_WhenArgumentMatchesRegex(string regex,
                string argument)
            {
                argument.GuardMatchesRegex(new Regex(regex), nameof(argument));
            }

            [Theory]
            [InlineData(REGEX, @"NONONO")]
            [InlineData(REGEX, @"http://coub/7cwh0")]
            [InlineData(REGEX, @"http://coub.com/foo")]
            public void GuardMatchesRegex_ShouldThrow_WhenArgumentDoesntMatcheRegex(string regex, string argument)
            {
                Assert.Throws<ArgumentException>(nameof(argument),
                    () => { argument.GuardMatchesRegex(new Regex(regex), nameof(argument)); });
            }
        }
    }
}