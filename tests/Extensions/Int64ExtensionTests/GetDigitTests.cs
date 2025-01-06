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

}
