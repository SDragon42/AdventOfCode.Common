using System.IO;

namespace AdventOfCode.Common.Tests.Services;

public class NumbersServiceTests
{
    private readonly INumbersService _numbersService = new NumbersService();


    [Theory]
    [InlineData(18, 27, 9)]
    [InlineData(60, 40, 20)]
    [InlineData(100, 150, 50)]
    [InlineData(144, 24, 24)]
    [InlineData(17, 89, 1)]
    [InlineData(0, 9, 9)]
    [InlineData(12, 12, 12)]
    public void HighestCommonFactor_TwoValues_ReturnsExpected(long a, long b, long expected)
    {
        var result = _numbersService.HighestCommonFactor(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(126, 162, 180, 18)]
    [InlineData(150, 100, 20, 10)]
    [InlineData(18, 30, 12, 6)]
    public void HighestCommonFactor_ValidListOfValues_ReturnsExpected(long a, long b, long c, long expected)
    {
        var result = _numbersService.HighestCommonFactor([a, b, c]);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void HighestCommonFactor_TwoItemList_ReturnsExpected()
    {
        Assert.Equal(6, _numbersService.HighestCommonFactor(new long[] { 18, 24 }));
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




    [Theory]
    [InlineData(2, 5, 10)]
    [InlineData(60, 90, 180)]
    [InlineData(21, 12, 84)]
    [InlineData(long.MaxValue, long.MaxValue, long.MaxValue)]
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
        yield return new object[] { new long[] { long.MaxValue, long.MaxValue }, long.MaxValue };
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
        yield return new object[] { new long[] { 5 } };
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
