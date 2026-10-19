namespace AdventOfCode.Common.Tests.Services;

public class NumbersServiceTests
{
    private readonly NumbersService _numbersService = new();


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
        Assert.Equal(6, _numbersService.HighestCommonFactor([18, 24]));
    }

    [Theory]
    [MemberData(nameof(Data_HighestCommonFactor_NullList_ThrowsArgumentException))]
    public void HighestCommonFactor_NullList_ThrowsArgumentException(long[] values)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.HighestCommonFactor(values));
    }
    public static TheoryData<long[]> Data_HighestCommonFactor_NullList_ThrowsArgumentException()
    {
        var data = new TheoryData<long[]>
        {
            null!,
            Array.Empty<long>(),
            ([42])
        };
        return data;
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
    public void LowestCommonMultiple_ValidListOfNumbers_ReturnsExpected(long[] values, long expected)
    {
        var result = _numbersService.LowestCommonMultiple(values);

        Assert.Equal(expected, result);
    }
    public static TheoryData<long[], long> Data_LowestCommonMultiple_ValidListOfNumbers()
    {
        var data = new TheoryData<long[], long>
        {
            { [2, 5], 10 },
            { [60, 90], 180 },
            { [21, 12], 84 },
            { [25, 15, 30], 150 },
            { [long.MaxValue, long.MaxValue], long.MaxValue }
        };
        return data;
    }


    [Theory]
    [MemberData(nameof(Data_LowestCommonMultiple_InvalidListOfNumbers))]
    public void LowestCommonMultiple_InvalidListOfNumbers_ShouldThrowArgumentException(long[] values)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.LowestCommonMultiple(values));
    }
    public static TheoryData<long[]> Data_LowestCommonMultiple_InvalidListOfNumbers()
    {
        var data = new TheoryData<long[]>
        {
            { Array.Empty<long>() },
            { [5] },
            { [-1, 5] },
            { [0, 10] },
            { [25, -15, 30] }
        };
        return data;
    }


    [Theory]
    [MemberData(nameof(Data_LowestCommonMultiple_NullList_ThrowsArgumentException))]
    public void LowestCommonMultiple_NullList_ThrowsArgumentException(long[] values)
    {
        Assert.Throws<ArgumentException>(() => _numbersService.LowestCommonMultiple(values));
    }
    public static TheoryData<long[]> Data_LowestCommonMultiple_NullList_ThrowsArgumentException()
    {
        var data = new TheoryData<long[]>
        {
            { null! }
        };
        return data;
    }
}
