namespace AdventOfCode.Common.Tests.Extensions.Int32ExtensionsTests;

public class GetDigitTests
{
    [Theory]
    [InlineData(123456789, 1, false, 9)]
    [InlineData(123456789, 2, false, 8)]
    [InlineData(123456789, 1,true, 1)]
    [InlineData(123456789, 2, true, 2)]
    [InlineData(42, 2, true, 2)]
    [InlineData(123456, 2, true, 2)]
    public void GetDigit_WithValidNumber_ReturnsDigit(int value, int offset, bool fromTheLeft, int expected)
    {
        var result = value.GetDigit(offset, fromTheLeft);

        Assert.Equal(expected, result);
    }

}
