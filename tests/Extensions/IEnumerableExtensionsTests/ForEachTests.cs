namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class ForEachTests : IEnumerableExtensionsTestBase
{
    public ForEachTests(ITestOutputHelper output) : base(output) { }



    [Fact]
    public void ForEach_ValidSource_HitsEveryElement()
    {
        var items = GetTestData();
        var expected = items.Sum();

        int sumTotal = 0;
        var action = (int value) => { sumTotal += value; };

        IEnumerableExtensions.ForEach(items, action);

        Assert.Equal(expected, sumTotal);
    }

    [Fact]
    public void ForEach_NullSource_ThrowsException()
    {
        List<int>? items = default;

        var action = (int value) => { var x = value; };

        Assert.Throws<ArgumentNullException>(
            () => IEnumerableExtensions.ForEach(items, action));
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
