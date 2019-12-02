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
        [InlineData("warning")]
        public void GetFirstWarning_ShouldReturnFirstWarning(string warning)
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddWarning(warning);
            sr.AddWarning("bleh");

            // Assert
            sr.GetFirstWarning().ShouldBe(warning);
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
        [InlineData("")]
        [InlineData(null)]
        public void AddError_ShouldArgumentNullException_WhenNullOrEmptyError(string error)
        {
            // Act & assert
            Assert.Throws<ArgumentException>(() =>
            {
                var sr = new ServiceResult();
                sr.AddError(error);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void AddWarning_ShouldArgumentNullException_WhenNullOrEmptyError(string warning)
        {
            // Act & assert
            Assert.Throws<ArgumentException>(() =>
            {
                var sr = new ServiceResult();
                sr.AddWarning(warning);
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
        public void Errors_ShouldRetrieveAllErrors()
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
        public void HasWarnings_ShouldBeTrue_WhenWarnings()
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddWarning("test");

            // Assert
            sr.HasWarnings.ShouldBeTrue();
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
        public void Warnings_ShouldRetrieveAllWarnings()
        {
            // Arrange
            var sr = new ServiceResult();

            // Act
            sr.AddWarning("warning 1");
            sr.AddWarning("warning 2");

            // Assert
            Assert.Collection(sr.Warnings,
                x => x.ShouldBe("warning 1"),
                x => x.ShouldBe("warning 2")
            );
        }

        [Fact]
        public void Succeed_ShouldReturnResultWithSuccess()
        {
            // Act && assert
            ServiceResult.Succeed().Success.ShouldBeTrue();
        }

        [Fact]
        public void Succeed_ShouldSetData()
        {
            // Act
            var result = ServiceResult<string>.Succeed("result");

            // Assert
            result.ShouldBeOfType<ServiceResult<string>>();
            result.Success.ShouldBeTrue();
            result.Data.ShouldBe("result");
        }

        [Fact]
        public void Failed_ShouldRetrieveAllErrors()
        {
            // Act
            var sr = ServiceResult.Failed("error 1", "error 2");

            // Assert
            Assert.Collection(sr.Errors,
                x => x.ShouldBe("error 1"),
                x => x.ShouldBe("error 2")
            );
        }

        [Fact]
        public void Failed_ShouldReturnWithType()
        {
            // Act && assert
            ServiceResult<string>.Failed("error 1", "error 2")
                .ShouldBeOfType<ServiceResult<string>>();
        }
    }
}
