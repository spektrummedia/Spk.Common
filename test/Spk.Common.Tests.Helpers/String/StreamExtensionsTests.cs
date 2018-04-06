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
            var streamUnderTest = input.ToStream();

            // Assert
            streamUnderTest.ShouldNotBeNull();
            var streamReader = new StreamReader(streamUnderTest);
            var message = await streamReader.ReadToEndAsync();

            message.ShouldBe(input);
        }
    }

}
