namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class WindowedTests(ITestOutputHelper output) : IEnumerableExtensionsTestBase(output)
{
    public static TheoryData<int, int> Windowed_SmallerSize_ReturnsExpectedElements_Params()
    {
        var data = new TheoryData<int, int>();
        var count = GetTestData().Count;
        for (int windowSize = 1; windowSize <= count + 1; windowSize++)
        {
            var expectedNumWindows = count - windowSize + 1;
            data.Add(windowSize, expectedNumWindows);
        }

        return data;
    }
    [Theory]
    [MemberData(nameof(Windowed_SmallerSize_ReturnsExpectedElements_Params))]
    public void Windowed_ValidSize_ReturnsWindows(int windowSize, int expected)
    {
        var items = GetTestData();

        var results = items.Windowed(windowSize);

        Assert.Equal(expected, results.Count());
    }



    public static TheoryData<int, int> Windowed_LargerSize_ReturnsNothing_Params()
    {
        var data = new TheoryData<int, int>();
        var count = GetTestData().Count;
        var windowSize = count + 1;
        data.Add(windowSize, 0);
        return data;
    }
    [Theory]
    [MemberData(nameof(Windowed_LargerSize_ReturnsNothing_Params))]
    public void Windowed_LargerSize_ReturnsNothing(int windowSize, int expected)
    {
        var items = GetTestData();

        var results = items.Windowed(windowSize);

        Assert.Equal(expected, results.Count());
    }



    [Theory]
    [InlineData(3, 0, 0, 1, 2)]
    [InlineData(3, 1, 1, 2, 3)]
    [InlineData(2, 4, 4, 5)]
    public void Windowed_Valid_ReturnsExpectedElements(int windowSize, int offset, params int[] expected)
    {
        var items = GetTestData();

        var parts = items.Windowed(windowSize);
        var results = parts.Skip(offset).First();

        Assert.Equal<int>(expected, results);
    }



    [Fact]
    public void Windowed_NullSource_ThrowsException()
    {
        List<int>? items = default;
        var windowSize = 2;

        void action()
        {
            var windows = IEnumerableExtensions
                .Windowed(items, windowSize)
                .ToArray();
        }

        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void Windowed_InvalidSize_ThrowsException()
    {
        var items = GetTestData();
        var windowSize = 0;

        void action()
        {
            var windows = IEnumerableExtensions
                .Windowed(items, windowSize)
                .ToArray();
        }

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

}
