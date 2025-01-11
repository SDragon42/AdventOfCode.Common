using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Common.Services.Interfaces;

namespace AdventOfCode.Common.Services
{
    public class InputReaderService : IInputReaderService
    {
        private readonly string _inputFolderPath;
        public InputReaderService(string inputFolderPath)
        {
            _inputFolderPath = inputFolderPath;
        }



        private string BuildDataFilePath(int day, string name)
        {
            var filename = Path.Combine(_inputFolderPath,
                                        $"Day{day:00}",
                                        $"{name}.txt");
            return filename;
        }

        public IEnumerable<string> ReadLines(int day, string name)
        {
            try
            {
                var path = BuildDataFilePath(day, name);
                return File.ReadLines(path);
            }
            catch { return null; }
        }

        public string ReadText(int day, string name)
        {
            var lines = ReadLines(day, name);
            if (lines == null)
                return null;

            var text = string.Join(Environment.NewLine, lines);
            return text?.Length > 0 ? text : null;
        }

    }
}
