using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode.Common.Models.Interfaces
{
    /// <summary>
    /// Represents a generic 2D grid.
    /// </summary>
    /// <typeparam name="TCell">The type of the cells in the grid.</typeparam>
    public interface IGrid<TCell>
    {
        /// <summary>
        /// Gets the total number of cells in the grid.
        /// </summary>
        int Count { get; }
        
        /// <summary>
        /// Gets the underlying list representing the grid.
        /// </summary>
        IList<TCell> Grid { get; }

        /// <summary>
        /// Determines whether the specified point is within the bounds of the grid.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns><c>true</c> if the point is within the bounds; otherwise, <c>false</c>.</returns>
        bool IsInBounds(Point point);

        /// <summary>
        /// Converts an array index to a grid x,y point.
        /// </summary>
        /// <param name="index">The array index.</param>
        /// <returns>The corresponding grid point.</returns>
        Point IndexToPoint(int index);

        /// <summary>
        /// Converts a grid x,y Point object to an array index.
        /// </summary>
        /// <param name="point">The grid point to convert.</param>
        /// <returns>The corresponding array index.</returns>
        int PointToIndex(Point point);

        /// <summary>
        /// Gets or sets the cell at the specified array index.
        /// </summary>
        /// <param name="i">The array index.</param>
        /// <returns>The cell at the specified index.</returns>
        TCell this[int i] { get; set; }

        /// <summary>
        /// Gets or sets the cell at the specified grid point.
        /// </summary>
        /// <param name="pt">The grid point.</param>
        /// <returns>The cell at the specified grid point.</returns>
        TCell this[Point pt] { get; set; }
    }
}
