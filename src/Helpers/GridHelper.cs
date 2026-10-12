using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode.Common.Helpers
{
    /// <summary>
    /// Provides helper methods for working with 2D grids.
    /// </summary>
    public static class GridHelper
    {
        /// <summary>
        /// Draws a 2D grid from the given point-based grid data.
        /// </summary>
        /// <typeparam name="TValue">The type of the grid elements.</typeparam>
        /// <param name="gridData">The point-based grid data.</param>
        /// <param name="DrawElementMethod">The method to draw each grid element.</param>
        /// <param name="minArea">The minimum area of the grid to draw.</param>
        /// <returns>The drawn grid as a string.</returns>
        public static string DrawPointGrid2D<TValue>(IDictionary<Point, TValue> gridData, Func<TValue, string> DrawElementMethod = null, Size? minArea = null)
        {
            var minX = gridData.Keys.Min(h => h.X);
            var maxX = gridData.Keys.Max(h => h.X);
            var minY = gridData.Keys.Min(h => h.Y);
            var maxY = gridData.Keys.Max(h => h.Y);

            if (minArea.HasValue)
            {
                var xDiff = minArea.Value.Width - Math.Abs(maxX - minX);
                var yDiff = minArea.Value.Height - Math.Abs(maxY - minY);

                if (xDiff > 0)
                {
                    var xPart = xDiff / 2;
                    minX -= xPart;
                    maxX += xDiff = xPart;
                }

                if (yDiff > 0)
                {
                    var yPart = yDiff / 2;
                    minY -= yPart;
                    maxY += yDiff = yPart;
                }
            }

            var text = new StringBuilder();
            for (int y = maxY; y >= minY; y--)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    var key = new Point(x, y);
                    var value = default(TValue);
                    if (gridData.ContainsKey(key))
                        value = gridData[key];

                    var element = DrawElementMethod?.Invoke(value) ?? value?.ToString() ?? " ";
                    text.Append(element);
                }
                if (y > minY)
                    text.AppendLine();
            }

            var result = text.ToString();
            return result;
        }


        /// <summary>
        /// Draws a 2D grid from the given point-based grid data.
        /// </summary>
        /// <typeparam name="TValue">The type of the grid elements.</typeparam>
        /// <param name="gridData">The point-based grid data.</param>
        /// <param name="DrawElementMethod">The method to draw each grid element.</param>
        /// <returns>The drawn grid as a string.</returns>
        public static string DrawScreenGrid2D<TValue>(IDictionary<Point, TValue> gridData, Func<TValue, string> DrawElementMethod = null)
        {
            var minX = gridData.Keys.Min(h => h.X);
            var maxX = gridData.Keys.Max(h => h.X);
            var minY = gridData.Keys.Min(h => h.Y);
            var maxY = gridData.Keys.Max(h => h.Y);

            var text = new StringBuilder();
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    var key = new Point(x, y);
                    var value = default(TValue);
                    if (gridData.ContainsKey(key))
                        value = gridData[key];

                    var element = DrawElementMethod?.Invoke(value) ?? value.ToString();
                    text.Append(element);
                }
                text.AppendLine();
            }

            return text.ToString();
        }


        /// <summary>
        /// Draws a 2D grid from the given list-based grid data.
        /// </summary>
        /// <typeparam name="TValue">The type of the grid elements.</typeparam>
        /// <param name="gridData">The list-based grid data.</param>
        /// <param name="DrawElementMethod">The method to draw each grid element.</param>
        /// <returns>The drawn grid as a string.</returns>
        public static string DrawScreenGrid2D<TValue>(IList<IList<TValue>> gridData, Func<TValue, string> DrawElementMethod = null)
        {
            var minX = 0;
            var maxX = gridData[0].Count - 1;
            var minY = 0;
            var maxY = gridData.Count - 1;

            var text = new StringBuilder();
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    var value = gridData[y][x];

                    var element = DrawElementMethod?.Invoke(value) ?? value.ToString();
                    text.Append(element);
                }
                text.AppendLine();
            }

            return text.ToString();
        }


        /// <summary>
        /// Converts an array index to a grid x,y point.
        /// </summary>
        /// <param name="index">The array index.</param>
        /// <param name="xMax">The width of the grid.</param>
        /// <param name="origin">The origin point of the grid (optional).</param>
        /// <returns>The corresponding grid point.</returns>
        public static Point IndexToPoint(int index, int xMax, Point? origin = null)
        {
            var x = (index % xMax) + (origin?.X ?? 0);
            var y = (index / xMax) + (origin?.Y ?? 0);

            return new Point(x, y);
        }

        /// <summary>
        /// Converts a grid x.y Point object to an array index.
        /// </summary>
        /// <param name="point">The grid point to convert.</param>
        /// <param name="xMax">The width of the grid.</param>
        /// <param name="origin">The origin point of the grid (optional).</param>
        /// <returns>The corresponding array index.</returns>
        public static int PointToIndex(Point point, int xMax, Point? origin = null)
        {
            var x = point.X + (origin?.X ?? 0);
            var y = point.Y + (origin?.Y ?? 0);

            var index = y * xMax + x;
            return index;
        }
    }
}
