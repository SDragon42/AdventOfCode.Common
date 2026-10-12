using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Common.Helpers;
using AdventOfCode.Common.Models.Interfaces;

namespace AdventOfCode.Common.Models
{
    /// <summary>
    /// Represents a 2D grid backed by a one-dimensional array.
    /// </summary>
    /// <typeparam name="TCell">The type of the cells in the grid.</typeparam>
    public sealed class ArrayGrid<TCell> : IGrid<TCell>
    {
        private readonly TCell[] _grid;
        private readonly int _xSize;
        private readonly int _ySize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayGrid{TCell}"/> class from the given lines of text.
        /// </summary>
        /// <param name="lines">The lines of text representing the grid.</param>
        /// <param name="transformMethod">The method to transform each character into a grid cell.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="lines"/> or <paramref name="transformMethod"/> is null.</exception>
        public ArrayGrid(IList<string> lines, Func<char, TCell> transformMethod)
        {
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            if (transformMethod == null)
                throw new ArgumentNullException(nameof(transformMethod));

            _ySize = lines.Count;
            _xSize = lines.First().Length;
            _grid = lines.SelectMany(l => l.Select(transformMethod)).ToArray();
        }


        /// <inheritdoc/>
        public int Count => _grid.Length;
        /// <inheritdoc/>
        public IList<TCell> Grid => _grid;



        /// <inheritdoc/>
        public bool IsInBounds(Point point)
        {
            return 0 <= point.X && point.X < _xSize
                && 0 <= point.Y && point.Y < _ySize;
        }

        /// <inheritdoc/>
        public Point IndexToPoint(int index) => GridHelper.IndexToPoint(index, _xSize);
        
        
        /// <inheritdoc/>
        public int PointToIndex(Point point) => GridHelper.PointToIndex(point, _xSize);
        
        
        
        /// <summary>
        /// Gets or sets the cell at the specified array index.
        /// </summary>
        /// <param name="index">The array index.</param>
        /// <returns>The cell at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is out of bounds.</exception>
        public TCell this[int index]
        {
            get => IsInBounds(IndexToPoint(index))
                        ? _grid[index]
                        : throw new IndexOutOfRangeException();
            set => _grid[index] = IsInBounds(IndexToPoint(index))
                        ? value
                        : throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Gets or sets the cell at the specified grid point.
        /// </summary>
        /// <param name="point">The grid point.</param>
        /// <returns>The cell at the specified grid point.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the point is out of bounds.</exception>
        public TCell this[Point point]
        {
            get => IsInBounds(point)
                        ? _grid[PointToIndex(point)]
                        : throw new IndexOutOfRangeException();
            set => _grid[PointToIndex(point)] = IsInBounds(point)
                        ? value
                        : throw new IndexOutOfRangeException();
        }

    }
}
