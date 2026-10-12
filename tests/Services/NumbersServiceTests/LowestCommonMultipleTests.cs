namespace AdventOfCode.Common.Tests.Services.NumbersServiceTests;

public class LowestCommonMultipleTests : NumbersServiceTestBase
{
    [Theory]
    [InlineData(2, 5, 10)]
    [InlineData(60, 90, 180)]
    [InlineData(21, 12, 84)]
    public void LowestCommonMultiple_ValidPairOfNumbers_ReturnsExpected(long a, long b, long expected)
    {
        var result = _numbersService.LowestCommonMultiple(a, b);

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(0, 5)]
    [InlineData(60, -90)]
    [InlineData(-21, -12)]
    public void LowestCommonMultiple_InvalidPairOfNumbers_ReturnsExpected(long a, long b)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.LowestCommonMultiple(a, b));
    }


    [Theory]
    [MemberData(nameof(Data_LowestCommonMultiple_ValidListOfNumbers))]
    public void LowestCommonMultiple_ValidListOfNumbers_ReturnsExpected(IList<long> values, long expected)
    {
        var result = _numbersService.LowestCommonMultiple(values);

        Assert.Equal(expected, result);
    }
    public static IEnumerable<object[]> Data_LowestCommonMultiple_ValidListOfNumbers()
    {
        yield return new object[] { new long[] { 2, 5 }, 10 };
        yield return new object[] { new long[] { 60, 90 }, 180 };
        yield return new object[] { new long[] { 21, 12 }, 84 };
        yield return new object[] { new long[] { 25, 15, 30 }, 150 };
    }


    [Theory]
    [MemberData(nameof(Data_LowestCommonMultiple_InvalidListOfNumbers))]
    public void LowestCommonMultiple_InvalidListOfNumbers_ShouldThrowArgumentException(IList<long> values)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.LowestCommonMultiple(values));
    }
    public static IEnumerable<object[]> Data_LowestCommonMultiple_InvalidListOfNumbers()
    {
        yield return new object[] { Array.Empty<long>() };
        yield return new object[] { new long[] { -1, 5 } };
        yield return new object[] { new long[] { 0, 10 } };
        yield return new object[] { new long[] { 25, -15, 30 } };
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
    }
}
