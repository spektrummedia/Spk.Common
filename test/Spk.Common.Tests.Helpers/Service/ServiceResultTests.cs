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

        [Fact]
        public void Success_ShouldBeFalse_WhenErrors()
        {
            // Arrange
            var sr = new ServiceResult<string>();

            // Act
            sr.AddError("test");

            // Assert
            sr.Success.ShouldBeFalse();
        }

        [Fact]
        public void Errors_ShouldRetrivedAllErrors()
        {
            // Arrange
            var sr = new ServiceResult<string>();

            // Act
            sr.AddError("error 1");
            sr.AddError("error 2");


            // Assert
            sr.Errors.Count.ShouldBe(2);
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
