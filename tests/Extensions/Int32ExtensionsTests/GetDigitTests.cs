namespace AdventOfCode.Common.Tests.Extensions.Int32ExtensionsTests;

public class GetDigitTests
{
    [Theory]
    [InlineData(123456789, 1, false, 9)]
    [InlineData(123456789, 2, false, 8)]
    [InlineData(123456789, 1, true, 1)]
    [InlineData(123456789, 2, true, 2)]
    [InlineData(42, 2, true, 2)]
    [InlineData(123456, 2, true, 2)]
    public void GetDigit_WithValidNumber_ReturnsDigit(int value, int offset, bool fromTheLeft, int expected)
    {
        var result = value.GetDigit(offset, fromTheLeft);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetDigit_DefaultsToCountingFromTheRight()
    {
        Assert.Equal(3, 123.GetDigit(1));
    }

    [Theory]
    [InlineData(0, 1, false, 0)]
    [InlineData(0, 1, true, 0)]
    [InlineData(123, 4, false, 0)]
    public void GetDigit_ZeroOrPositionBeyondDigits_ReturnsExpectedDigit(int value, int position, bool fromTheLeft, int expected)
    {
        Assert.Equal(expected, value.GetDigit(position, fromTheLeft));
    }

}
