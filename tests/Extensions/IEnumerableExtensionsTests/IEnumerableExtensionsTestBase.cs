namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public abstract class IEnumerableExtensionsTestBase
{
    protected readonly ITestOutputHelper _output;

    public IEnumerableExtensionsTestBase(ITestOutputHelper output)
    {
        _output = output;
    }


    protected static IList<int> GetTestData()
    {
        var items = Enumerable.Range(0, 10)
                              .ToList();
        return items;
    }

}
