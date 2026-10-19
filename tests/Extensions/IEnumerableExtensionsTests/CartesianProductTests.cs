namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class CartesianProductTests(ITestOutputHelper output) : IEnumerableExtensionsTestBase(output)
{
    [Fact]
    public void CartesianProduct_MultipleSequences_ReturnsEveryCombination()
    {
        IEnumerable<IEnumerable<int>> sequences =
        [
            [1, 2],
            [3, 4]
        ];

        var result = sequences.CartesianProduct()
            .Select(values => string.Join(",", values))
            .ToArray();

        Assert.Equal(["1,3", "1,4", "2,3", "2,4"], result);
    }

    [Fact]
    public void CartesianProduct_NoSequences_ReturnsOneEmptyCombination()
    {
        var result = Enumerable.Empty<IEnumerable<int>>()
            .CartesianProduct()
            .ToArray();

        Assert.Single(result);
        Assert.Empty(result[0]);
    }

    [Fact]
    public void CartesianProduct_ContainsEmptySequence_ReturnsNoCombinations()
    {
        IEnumerable<IEnumerable<int>> sequences =
        [
            [1, 2],
            []
        ];

        Assert.Empty(sequences.CartesianProduct());
    }
}
