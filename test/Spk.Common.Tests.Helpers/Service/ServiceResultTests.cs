using System;
using System.Linq;
using Shouldly;
using Spk.Common.Helpers.Service;
using Xunit;

namespace Spk.Common.Tests.Helpers.Service
{
    public class ServiceResultTests
    {
        [Theory]
        [InlineData("data result")]
        public void Constructor_ShouldSetData_WhenParameterProvided(string data)
        {
            // Arrange & act
            var sr = new ServiceResult<string>(data);

            // Assert
            sr.Data.ShouldBe(data);
        }

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
        [InlineData("error")]
        public void GetFirstError_ShouldReturnFirstError(string error)
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddError(error);
            sr.AddError("bleh");

            // Assert
            sr.GetFirstError().ShouldBe(error);
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
        public void AddError_ShouldArgumentNullException_WhenNullError()
        {
            // Act & assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var sr = new ServiceResult();
                sr.AddError(null);
            });
        }

        [Fact]
        public void AddWarning_ShouldArgumentNullException_WhenNullError()
        {
            // Act & assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var sr = new ServiceResult();
                sr.AddWarning(null);
            });
        }

        [Fact]
        public void Constructor_WithData_ShouldInitializeErrorCollection()
        {
            // Arrange & act
            var sr = new ServiceResult<string>("bleh");

            // Assert
            sr.Errors.ShouldNotBeNull();
            sr.Errors.ShouldBeEmpty();
        }

        [Fact]
        public void Constructor_WithData_ShouldThrow_WhenArgumentIsNull()
        {
            // Arrange & act & assert
            Assert.Throws<ArgumentNullException>(() => new ServiceResult<string>(null));
        }

        [Fact]
        public void DefaultConstructor_ShouldInitializeErrorCollection()
        {
            // Arrange & act
            var sr = new ServiceResult<string>();

            // Assert
            sr.Errors.ShouldNotBeNull();
            sr.Errors.ShouldBeEmpty();
        }

        [Fact]
        public void Errors_ShouldRetriveAllErrors()
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddError("error 1");
            sr.AddError("error 2");


            // Assert
            sr.Errors.Count().ShouldBe(2);
        }

        [Fact]
        public void Success_ShouldBeFalse_WhenErrors()
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddError("test");

            // Assert
            sr.Success.ShouldBeFalse();
        }

        [Fact]
        public void Success_ShouldBeTrue_WhenWarnings()
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddWarning("test");

            // Assert
            sr.Success.ShouldBeTrue();
        }

        [Fact]
        public void Warnings_ShouldRetriveAllWarnings()
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddWarning("error 1");
            sr.AddWarning("error 2");


            // Assert
            sr.Warnings.Count().ShouldBe(2);
        }
    }
}
