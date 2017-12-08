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
        public void SetData_ShouldSetData(string value)
        {
            // Arrange
            var sr = new ServiceResult<string>();

            // Act
            sr.SetData(value);

            // Assert
            sr.Data.ShouldBe(value);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("")]
        [InlineData(null)]
        public void Success_ShouldBeTrue_WhenDataIsSet(string value)
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
            sr.AddError("bleh");

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
