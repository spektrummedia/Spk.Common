using System.IO;
using Shouldly;
using Spk.Common.Helpers.String;
using Xunit;

namespace Spk.Common.Tests.Helpers.String
{
    public class StreamExtensionsTests
    {
        [Fact]
        public async void ToStream_ShouldTransformTheStringProperly()
        {
            // Arrange
            var expectedMessage = "Hello World";

            // Act
            var streamUnderTest = expectedMessage.ToStream();

            // Assert
            streamUnderTest.ShouldNotBeNull();
            var streamReader = new StreamReader(streamUnderTest);
            var message = await streamReader.ReadToEndAsync();

            message.ShouldBe(expectedMessage);
        }

        [Fact]
        public async void ToStream_ShouldTransformEmptyStringProperly()
        {
            // Arrange
            var expectedMessage = "";

            // Act
            var streamUnderTest = expectedMessage.ToStream();

            // Assert
            streamUnderTest.ShouldNotBeNull();
            var streamReader = new StreamReader(streamUnderTest);
            var message = await streamReader.ReadToEndAsync();

            message.ShouldBe(expectedMessage);
        }
    }

}
