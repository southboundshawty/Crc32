using Xunit;

namespace Crc32.Unit.Tests;

public class Crc32ExtensionsTests
{
    [Theory]
    [InlineData("hello", "3610a686")]
    [InlineData("world", "3a771143")]
    [InlineData("", "00000000")]
    public void ToCrc32_ShouldReturnExpectedValue(string input, string expected)
    {
        // Act
        var result = input.ToCrc32();
        
        // Assert
        Assert.Equal(expected, result);
    }
}