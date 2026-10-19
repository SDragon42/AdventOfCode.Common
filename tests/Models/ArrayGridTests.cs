using System.Drawing;
using AdventOfCode.Common.Models;

namespace AdventOfCode.Common.Tests.Models;

public class ArrayGridTests
{
    [Fact]
    public void Constructor_TransformsRowsAndExposesFlatGrid()
    {
        var grid = new ArrayGrid<int>(["12", "34"], character => character - '0');

        Assert.Equal(4, grid.Count);
        Assert.Equal([1, 2, 3, 4], grid.Grid);
    }

    [Fact]
    public void Constructor_NullLines_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new ArrayGrid<char>(null!, character => character));
    }

    [Fact]
    public void Constructor_NullTransform_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new ArrayGrid<char>(["a"], null!));
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(1, 1, true)]
    [InlineData(-1, 0, false)]
    [InlineData(3, 0, false)]
    [InlineData(0, -1, false)]
    [InlineData(0, 2, false)]
    public void IsInBounds_ReturnsWhetherPointIsInsideGrid(int x, int y, bool expected)
    {
        var grid = CreateGrid();

        Assert.Equal(expected, grid.IsInBounds(new Point(x, y)));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(2, 0, 2)]
    [InlineData(0, 1, 3)]
    [InlineData(2, 1, 5)]
    public void IndexAndPointConversions_AreRowMajor(int x, int y, int index)
    {
        var grid = CreateGrid();
        var point = new Point(x, y);

        Assert.Equal(point, grid.IndexToPoint(index));
        Assert.Equal(index, grid.PointToIndex(point));
    }

    [Fact]
    public void IndexerByIndex_GetsAndSetsCell()
    {
        var grid = CreateGrid();

        Assert.Equal('b', grid[1]);

        grid[1] = 'x';

        Assert.Equal('x', grid[1]);
    }

    [Fact]
    public void IndexerByPoint_GetsAndSetsCell()
    {
        var grid = CreateGrid();
        var point = new Point(2, 1);

        Assert.Equal('f', grid[point]);

        grid[point] = 'x';

        Assert.Equal('x', grid[point]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(6)]
    public void IndexerByIndex_OutOfBounds_ThrowsIndexOutOfRangeException(int index)
    {
        var grid = CreateGrid();

        Assert.Throws<IndexOutOfRangeException>(() => _ = grid[index]);
        Assert.Throws<IndexOutOfRangeException>(() => grid[index] = 'x');
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(3, 0)]
    [InlineData(0, -1)]
    [InlineData(0, 2)]
    public void IndexerByPoint_OutOfBounds_ThrowsIndexOutOfRangeException(int x, int y)
    {
        var grid = CreateGrid();
        var point = new Point(x, y);

        Assert.Throws<IndexOutOfRangeException>(() => _ = grid[point]);
        Assert.Throws<IndexOutOfRangeException>(() => grid[point] = 'x');
    }

    private static ArrayGrid<char> CreateGrid()
    {
        return new ArrayGrid<char>(["abc", "def"], character => character);
    }
}
