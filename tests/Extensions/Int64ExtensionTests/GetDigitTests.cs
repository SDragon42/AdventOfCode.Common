namespace AdventOfCode.Common.Tests.Extensions.Int64ExtensionTests;

public class GetDigitTests
{
    [Theory]
    [InlineData(123456789L, 1, false, 9)]
    [InlineData(123456789L, 2, false, 8)]
    [InlineData(123456789L, 1, true, 1)]
    [InlineData(123456789L, 2, true, 2)]
    [InlineData(42L, 2, true, 2)]
    [InlineData(123456L, 2, true, 2)]
    public void GetDigit_WithValidNumber_ReturnsDigit(long value, int offset, bool fromTheLeft, int expected)
    {
        var result = value.GetDigit(offset, fromTheLeft);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetDigit_DefaultsToCountingFromTheRight()
    {
        Assert.Equal(3, 123L.GetDigit(1));
    }

    [Theory]
    [InlineData(0L, 1, false, 0)]
    [InlineData(0L, 1, true, 0)]
    [InlineData(123L, 4, false, 0)]
    public void GetDigit_ZeroOrPositionBeyondDigits_ReturnsExpectedDigit(long value, int position, bool fromTheLeft, int expected)
    {
        Assert.Equal(expected, value.GetDigit(position, fromTheLeft));
    }

}
