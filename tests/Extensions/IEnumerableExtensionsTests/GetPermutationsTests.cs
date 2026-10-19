namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class GetPermutationsTests(ITestOutputHelper output) : IEnumerableExtensionsTestBase(output)
{
    [Fact]
    public void GetPermutations_ValidSource_ReturnsExpectedPermutations()
    {
        int[] input = [1, 2, 3];
        string[] expected = ["1,2,3", "1,3,2", "2,1,3", "2,3,1", "3,1,2", "3,2,1"];

        var results = IEnumerableExtensions.GetPermutations(input)
            .Select(permutation => string.Join(",", permutation))
            .ToList();

        Assert.Equal(expected.OrderBy(value => value), results.OrderBy(value => value));
    }

    [Fact]
    public void GetPermutations_SingleItem_ReturnsThatItem()
    {
        int[] input = [42];
        int[] expected = [42];
        var results = input.GetPermutations()
            .Select(permutation => permutation.ToArray())
            .ToArray();

        Assert.Equal(expected, Assert.Single(results));
    }

}
