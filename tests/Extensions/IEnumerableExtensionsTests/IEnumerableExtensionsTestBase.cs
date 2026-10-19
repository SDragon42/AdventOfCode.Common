namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public abstract class IEnumerableExtensionsTestBase(ITestOutputHelper output)
{
    protected readonly ITestOutputHelper _output = output;

    protected static IList<int> GetTestData()
    {
        var items = Enumerable.Range(0, 10)
                              .ToList();
        return items;
    }

}
