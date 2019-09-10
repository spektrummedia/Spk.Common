using System;
using System.IO;
using Shouldly;
using Spk.Common.Helpers.String;
using Xunit;

namespace Spk.Common.Tests.Helpers.String
{
    public class StreamExtensionsTests
    {
        [Theory]
        [InlineData("Hello World")]
        [InlineData("")]
        public async void ToStream_ShouldTransformTheStringProperly(string input)
        {
            // Act
            var streamUnderTest = input.ToMemoryStream();

            // Assert
            streamUnderTest.ShouldNotBeNull();
            var streamReader = new StreamReader(streamUnderTest);
            var message = await streamReader.ReadToEndAsync();

            message.ShouldBe(input);
        }

        [Fact]
        public void ToStream_Should_Throw_When_Source_Is_Null()
        {
            // Act
            var exception = Record.Exception(() => ((string)null).ToMemoryStream());

            // Assert
            exception.ShouldBeOfType<ArgumentNullException>();

        }
    }

}
