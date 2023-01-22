using Xunit;

namespace Crc32.Unit.Tests;

public class Crc32ExtensionsTests
{
    [Theory]
    [InlineData("hello", "185f9656")]
    [InlineData("world", "1cbf0835")]
    [InlineData("", "00000000")]
    [InlineData("xunit", "b0f9c966")]
    [InlineData("fluent", "2f2b7c3b")]
    [InlineData("inline", "9a9a1a2a")]
    public void ToCrc32_ShouldReturnExpectedValue(string input, string expected)
    {
        // Act
        var result = input.ToCrc32();

        // Assert
        Assert.Equal(expected, result);
    }
}