namespace AdventOfCode.Common.Tests.Extensions.StringExtensionsTests;

public class ToInt64Tests
{
    [Theory]
    [InlineData("42", 42L)]
    [InlineData("0", 0L)]
    [InlineData("-3", -3L)]
    [InlineData("-2147483648", -2_147_483_648L)]
    [InlineData("2147483647", 2_147_483_647L)]
    [InlineData("-9223372036854775808", -9_223_372_036_854_775_808L)]
    [InlineData("9223372036854775807", 9_223_372_036_854_775_807L)]
    public void ToInt64_NumberString_ReturnsLong(string value, long expected)
    {
        var result = StringExtensions.ToInt64(value);
        Assert.Equal(expected, result);
    }
}
