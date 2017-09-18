using NUnit.Framework;
using Spk.Common.Validators.String;

namespace Spk.Common.Tests.Validators.String
{
    public class EmailValidatorTests
    {
        private const string TOO_LONG_EMAIL =
            "14Nizq7x1E88XOCyHLdZQdODWABqX5K8JBmilzRCUPvOLaZOBJHt5EZnoxHqChZwLaMsHJuAhSKPH9BCW2fTsZF15gKfSyzQBttkYaTMXwsXxSGHRUWEIs4FY9gL7VSoYxrs6X1lW3Car6x5bvb09AoUtFXN2MOsNp33UDUhKdOFecrttIqroj2OXvnfoAhKzOtaYXfhlyRg930CxqI8xz64EnxeKRveQKV3HdgZzGglv@spektrummedia.com";

        [Test]
        public void IsValidEmail_ShouldReturnFalse_WhenEmailIsInvalid()
        {
            var invalidEmail = "@spektrummedia.com";
            Assert.IsFalse(invalidEmail.IsValidEmail());

            invalidEmail = "-@spektrummedia.com";
            Assert.IsFalse(invalidEmail.IsValidEmail());

            invalidEmail = "@(%)@%)-@spektrummedia.com";
            Assert.IsFalse(invalidEmail.IsValidEmail());
        }

        [Test]
        public void IsValidEmail_ShouldReturnFalse_WhenEmailLengthIsTooHigh()
        {
            Assert.IsFalse(TOO_LONG_EMAIL.IsValidEmail());
        }

        [Test]
        public void IsValidEmail_ShouldReturnTrue_WhenEmailValid()
        {
            var validEmail = "test@spektrummedia.com";
            Assert.IsTrue(validEmail.IsValidEmail());

            validEmail = "test+test@spektrummedia.com";
            Assert.IsTrue(validEmail.IsValidEmail());

            validEmail = "a@spektrummedia.com";
            Assert.IsTrue(validEmail.IsValidEmail());

            validEmail = "123123@spektrummedia.com";
            Assert.IsTrue(validEmail.IsValidEmail());
        }
    }
}