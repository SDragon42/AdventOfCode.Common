namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class GetPermutationsTests : IEnumerableExtensionsTestBase
{
    public GetPermutationsTests(ITestOutputHelper output) : base(output) { }

    [Fact]
    public void GetPermutations_ValidSource_ReturnsExpectedPermutations()
    {
        var input = new[] { 1, 2, 3 };
        var expected = new[] { "1,2,3", "1,3,2", "2,1,3", "2,3,1", "3,1,2", "3,2,1" };

        var results = IEnumerableExtensions.GetPermutations(input)
            .Select(permutation => string.Join(",", permutation))
            .ToList();

        Assert.Equal(expected.OrderBy(value => value), results.OrderBy(value => value));
    }

    [Fact]
    public void GetPermutations_SingleItem_ReturnsThatItem()
    {
        var results = new[] { 42 }.GetPermutations()
            .Select(permutation => permutation.ToArray())
            .ToArray();

        Assert.Equal(new[] { 42 }, Assert.Single(results));
    }

}
