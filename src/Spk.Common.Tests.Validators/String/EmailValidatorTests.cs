using Spk.Common.Validators.String;
using Xunit;

namespace Spk.Common.Tests.Validators.String
{
    public class EmailValidatorTests
    {
        private const string TOO_LONG_EMAIL =
            "14Nizq7x1E88XOCyHLdZQdODWABqX5K8JBmilzRCUPvOLaZOBJHt5EZnoxHqChZwLaMsHJuAhSKPH9BCW2fTsZF15gKfSyzQBttkYaTMXwsXxSGHRUWEIs4FY9gL7VSoYxrs6X1lW3Car6x5bvb09AoUtFXN2MOsNp33UDUhKdOFecrttIqroj2OXvnfoAhKzOtaYXfhlyRg930CxqI8xz64EnxeKRveQKV3HdgZzGglv@spektrummedia.com";

        [Fact]
        public void IsValidEmail_ShouldReturnFalse_WhenEmailIsInvalid()
        {
            var invalidEmail = "@spektrummedia.com";
            Assert.False(invalidEmail.IsValidEmail());

            invalidEmail = "-@spektrummedia.com";
            Assert.False(invalidEmail.IsValidEmail());

            invalidEmail = "@(%)@%)-@spektrummedia.com";
            Assert.False(invalidEmail.IsValidEmail());
        }

        [Fact]
        public void IsValidEmail_ShouldReturnFalse_WhenEmailLengthIsTooHigh()
        {
            Assert.False(TOO_LONG_EMAIL.IsValidEmail());
        }

        [Fact]
        public void IsValidEmail_ShouldReturnTrue_WhenEmailValid()
        {
            var validEmail = "test@spektrummedia.com";
            Assert.True(validEmail.IsValidEmail());

            validEmail = "test+test@spektrummedia.com";
            Assert.True(validEmail.IsValidEmail());

            validEmail = "a@spektrummedia.com";
            Assert.True(validEmail.IsValidEmail());

            validEmail = "123123@spektrummedia.com";
            Assert.True(validEmail.IsValidEmail());
        }
    }
}