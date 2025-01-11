using System.Collections.Generic;

namespace AdventOfCode.Common.Services.Interfaces
{
    public interface IInputReaderService
    {
        /// <summary>
        /// Reads all lines from the input file.
        /// </summary>
        /// <param name="day">The puzzle day for the data files.</param>
        /// <param name="name">The name of the data file without extension.</param>
        /// <returns></returns>
        IEnumerable<string> ReadLines(int day, string name);

        /// <summary>
        /// Reads all text from the input file.
        /// </summary>
        /// <param name="day">The puzzle day for the data files.</param>
        /// <param name="name">The name of the data file without extension.</param>
        /// <returns></returns>
        string ReadText(int day, string name);
    }
}
