using System.Drawing;
using AdventOfCode.Common.Helpers;

namespace AdventOfCode.Common.Tests.Helpers;

public class GridHelperTests
{
    [Fact]
    public void DrawPointGrid2D_SparseGrid_RendersFromTopToBottom()
    {
        var grid = new Dictionary<Point, string>
        {
            [new Point(-1, 0)] = "A",
            [new Point(1, 1)] = "B"
        };

        var result = GridHelper.DrawPointGrid2D(grid);

        Assert.Equal(string.Join(Environment.NewLine, "  B", "A  "), result);
    }

    [Fact]
    public void DrawPointGrid2D_MinimumAreaAndDrawMethod_AreApplied()
    {
        var grid = new Dictionary<Point, int>
        {
            [new Point(0, 0)] = 1,
            [new Point(1, 1)] = 2
        };

        var result = GridHelper.DrawPointGrid2D(grid, value => value == 0 ? "." : value.ToString(), new Size(4, 4));

        Assert.Equal(string.Join(Environment.NewLine, "....", "..2.", ".1..", "...."), result);
    }

    [Fact]
    public void DrawScreenGrid2D_PointGrid_RendersRowsAndUsesDrawMethod()
    {
        var grid = new Dictionary<Point, string>
        {
            [new Point(0, 0)] = "a",
            [new Point(1, 0)] = "b",
            [new Point(0, 1)] = "c",
            [new Point(1, 1)] = "d"
        };

        var result = GridHelper.DrawScreenGrid2D(grid, value => value.ToUpperInvariant());

        Assert.Equal(string.Join(Environment.NewLine, "AB", "CD") + Environment.NewLine, result);
    }

    [Fact]
    public void DrawScreenGrid2D_PointGrid_UsesDefaultValueFormatting()
    {
        var grid = new Dictionary<Point, int>
        {
            [new Point(0, 0)] = 12
        };

        Assert.Equal("12" + Environment.NewLine, GridHelper.DrawScreenGrid2D(grid));
    }

    [Fact]
    public void DrawScreenGrid2D_ListGrid_RendersRowsAndUsesDrawMethod()
    {
        IList<IList<int>> grid = new List<IList<int>>
        {
            new List<int> { 1, 2 },
            new List<int> { 3, 4 }
        };

        var result = GridHelper.DrawScreenGrid2D(grid, value => $"[{value}]");

        Assert.Equal(string.Join(Environment.NewLine, "[1][2]", "[3][4]") + Environment.NewLine, result);
    }

    [Fact]
    public void DrawScreenGrid2D_ListGrid_UsesDefaultValueFormatting()
    {
        IList<IList<int>> grid = new List<IList<int>>
        {
            new List<int> { 1, 2 }
        };

        Assert.Equal("12" + Environment.NewLine, GridHelper.DrawScreenGrid2D(grid));
    }

    [Theory]
    [InlineData(0, 3, 0, 0)]
    [InlineData(5, 3, 2, 1)]
    [InlineData(8, 3, 2, 2)]
    public void IndexToPoint_ValidIndex_ReturnsGridPoint(int index, int width, int expectedX, int expectedY)
    {
        Assert.Equal(new Point(expectedX, expectedY), GridHelper.IndexToPoint(index, width));
    }

    [Fact]
    public void IndexToPoint_WithOrigin_OffsetsGridPoint()
    {
        Assert.Equal(new Point(12, -1), GridHelper.IndexToPoint(5, 3, new Point(10, -2)));
    }

    [Theory]
    [InlineData(0, 0, 3, 0)]
    [InlineData(2, 1, 3, 5)]
    [InlineData(2, 2, 3, 8)]
    public void PointToIndex_GridPoint_ReturnsIndex(int x, int y, int width, int expected)
    {
        Assert.Equal(expected, GridHelper.PointToIndex(new Point(x, y), width));
    }

    [Fact]
    public void PointToIndex_WithOrigin_IncludesOriginOffset()
    {
        Assert.Equal(6, GridHelper.PointToIndex(new Point(1, 0), 3, new Point(2, 1)));
    }
}
