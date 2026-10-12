namespace AdventOfCode.Common.Tests.Services.NumbersServiceTests;

public class LowestCommonMultipleTests : NumbersServiceTestBase
{
    [Theory]
    [InlineData(2, 5, 10)]
    [InlineData(60, 90, 180)]
    [InlineData(21, 12, 84)]
    public void LowestCommonMultiple_twoValues(long a, long b, long expected)
    {
        var result = _numbersService.LowestCommonMultiple([a, b]);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(25, 15, 30, 150)]
    public void LowestCommonMultiple_ValidListOfValues(long a, long b, long c, long expected)
    {
        var result = _numbersService.LowestCommonMultiple([a, b, c]);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 5, 0)]
    [InlineData(long.MinValue, 0, 0)]
    [InlineData(-2, 3, 6)]
    [InlineData(2_000_000_011, 2_000_000_033, 4_000_000_088_000_000_363)]
    public void LowestCommonMultiple_HandlesZeroSignsAndLargeValues(long a, long b, long expected)
    {
        var result = _numbersService.LowestCommonMultiple([a, b]);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(Data_LowestCommonMultiple_NullList_ThrowsArgumentException))]
    public void LowestCommonMultiple_NullList_ThrowsArgumentException(IList<long> values)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.LowestCommonMultiple(values));
    }
    public static IEnumerable<object[]> Data_LowestCommonMultiple_NullList_ThrowsArgumentException()
    {
        yield return new object[] { null! };
        yield return new object[] { new long[] { } };
    }
}
