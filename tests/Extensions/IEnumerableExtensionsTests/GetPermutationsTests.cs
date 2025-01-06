namespace AdventOfCode.Common.Tests.Extensions.IEnumerableExtensionsTests;

public class GetPermutationsTests : IEnumerableExtensionsTestBase
{
    public GetPermutationsTests(ITestOutputHelper output) : base(output) { }

    [Fact]
    public void GetPermutations_ValidSource_Returns()
    {
        var input = new[] { 1, 2, 3 };
        var expected = 6;

        var results = IEnumerableExtensions.GetPermutations(input)
            .ToList();

        // Show results in the test output
        foreach (var item in results)
        {
            var text = string.Join(",", item);
            _output.WriteLine($"({text})");
        }

        Assert.Equal(expected, results.Count());
    }

}
