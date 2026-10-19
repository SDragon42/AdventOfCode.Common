namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class ForEachTests(ITestOutputHelper output) : IEnumerableExtensionsTestBase(output)
{
    [Fact]
    public void ForEach_ValidSource_HitsEveryElement()
    {
        var items = GetTestData();
        var expected = items.Sum();

        int sumTotal = 0;
        void Action(int value) { sumTotal += value; }

        IEnumerableExtensions.ForEach(items, Action);

        Assert.Equal(expected, sumTotal);
    }

    [Fact]
    public void ForEach_NullSource_ThrowsException()
    {
        List<int>? items = default;

        static void Action(int value) { }

        Assert.Throws<ArgumentNullException>(
            () => IEnumerableExtensions.ForEach(items, Action));
    }

    [Fact]
    public void ForEach_NullAction_ThrowsException()
    {
        var items = GetTestData();

        Action<int>? action = null;

        Assert.Throws<ArgumentNullException>(
            () => IEnumerableExtensions.ForEach(items, action));
    }
}
