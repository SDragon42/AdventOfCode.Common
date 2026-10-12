using System.Collections.Generic;

namespace AdventOfCode.Common.Services.Interfaces
{
    /// <summary>
    /// Provides methods for reading input data for Advent of Code puzzles.
    /// </summary>
    public interface IInputReaderService
    {
        /// <summary>
        /// Reads all lines from the input file.
        /// </summary>
        /// <param name="day">The puzzle day for the data files.</param>
        /// <param name="name">The name of the data file without extension.</param>
        /// <returns>An enumerable collection of strings representing each line in the input file.</returns>
        IEnumerable<string> ReadLines(int day, string name);

        /// <summary>
        /// Reads all text from the input file.
        /// </summary>
        /// <param name="day">The puzzle day for the data files.</param>
        /// <param name="name">The name of the data file without extension.</param>
        /// <returns>The text from the input file, or null if an error occurs or the file is empty.</returns>
        string ReadText(int day, string name);
    }
}
