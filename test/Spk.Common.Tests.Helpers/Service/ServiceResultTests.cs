using System;
using Shouldly;
using Spk.Common.Helpers.Service;
using Xunit;

namespace Spk.Common.Tests.Helpers.Service
{
    public class ServiceResultTests
    {
        [Theory]
        [InlineData("test")]
        [InlineData("")]
        [InlineData(null)]
        public void SetData_SuccessShouldBeTrue(string value)
        {
            // Arrange
            var sr = new ServiceResult<string>();

            // Act
            sr.SetData(value);

            // Assert
            sr.Success.ShouldBeTrue();
        }

        [Theory]
        [InlineData("error")]
        public void GetFirstError_ShouldReturnFirstError(string error)
        {
            // Arrange
            var sr = new ServiceResult<string>();

            // Act
            sr.AddError(error);

            // Assert
            sr.GetFirstError().ShouldBe(error);
        }

        [Fact]
        public void AddError_ShouldArgumentNullException_WhenNullError()
        {
            // Act & assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var sr = new ServiceResult<string>();
                sr.AddError(null);
            });
        }
    }
}
