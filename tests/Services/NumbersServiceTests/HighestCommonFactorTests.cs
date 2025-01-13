namespace AdventOfCode.Common.Tests.Services.NumbersServiceTests;

public class HighestCommonFactorTests : NumbersServiceTestBase
{
    [Theory]
    [InlineData(18, 27, 9)]
    [InlineData(60, 40, 20)]
    [InlineData(100, 150, 50)]
    [InlineData(144, 24, 24)]
    [InlineData(17, 89, 1)]
    public void HighestCommonFactor_twoValues(long a, long b, long expected)
    {
        var result = _numbersService.HighestCommonFactor(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(126, 162, 180, 18)]
    [InlineData(150, 100, 20, 10)]
    public void HighestCommonFactor_ValidListOfValues(long a, long b, long c, long expected)
    {
        var result = _numbersService.HighestCommonFactor([a, b, c]);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(Data_HighestCommonFactor_NullList_ThrowsArgumentException))]
    public void HighestCommonFactor_NullList_ThrowsArgumentException(IList<long> values)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.HighestCommonFactor(values));
    }
    public static IEnumerable<object[]> Data_HighestCommonFactor_NullList_ThrowsArgumentException()
    {
        yield return new object[] { null! };
        yield return new object[] { new long[] { } };
        yield return new object[] { new long[] { 42 } };
    }
}