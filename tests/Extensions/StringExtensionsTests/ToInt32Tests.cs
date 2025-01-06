namespace AdventOfCode.Common.Tests.Extensions.StringExtensionsTests;

public class ToInt32Tests
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData("0", 0)]
    [InlineData("-3", -3)]
    [InlineData("-2147483648", -2_147_483_648)]
    [InlineData("2147483647", 2_147_483_647)]
    public void ToInt32_NumberString_ReturnsInt(string value, int expected)
    {
        var result = StringExtensions.ToInt32(value);
        Assert.Equal(expected, result);
    }
}
