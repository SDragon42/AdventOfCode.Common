using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Common.Helpers;
using AdventOfCode.Common.Models.Interfaces;

namespace AdventOfCode.Common.Models
{
    public class ArrayGrid<TCell> : IGrid<TCell>
    {
        private TCell[] _grid;
        private int _xSize;
        private int _ySize;

        public ArrayGrid(IList<string> lines, Func<char, TCell> transformMethod)
        {
            _ySize = lines.Count;
            _xSize = lines.First().Length;
            _grid = lines.SelectMany(l => l.Select(transformMethod)).ToArray();
        }



        public int Count => _grid.Length;
        public IList<TCell> Grid => _grid;



        public bool IsInBounds(Point point)
        {
            return 0 <= point.X && point.X < _xSize
                && 0 <= point.Y && point.Y < _ySize;
        }

        public Point IndexToPoint(int index) => GridHelper.IndexToPoint(index, _xSize);
        
        
        public int PointToIndex(Point point) => GridHelper.PointToIndex(point, _xSize);
        
        

        public TCell this[int index]
        {
            get => IsInBounds(IndexToPoint(index))
                        ? _grid[index]
                        : throw new IndexOutOfRangeException();
            set => _grid[index] = IsInBounds(IndexToPoint(index))
                        ? value
                        : throw new IndexOutOfRangeException();
        }

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
