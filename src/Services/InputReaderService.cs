using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Common.Services.Interfaces;

namespace AdventOfCode.Common.Services
{
    /// <summary>
    /// Provides methods to read input data from files.
    /// </summary>
    public sealed class InputReaderService : IInputReaderService
    {
        private readonly string _inputFolderPath;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="InputReaderService"/> class using the local input path file.
        /// </summary>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public InputReaderService()
        {
            var inputFolderPath = ReadLocalFile();
            if (string.IsNullOrWhiteSpace(inputFolderPath))
            {
                throw new ArgumentException("Input folder path cannot be null or whitespace.", nameof(inputFolderPath));
            }

            _inputFolderPath = NormalizePath(inputFolderPath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputReaderService"/> class with the specified input folder path.
        /// </summary>
        /// <param name="inputFolderPath">The path to the folder containing input files.</param>
        public InputReaderService(string inputFolderPath)
        {
            if (string.IsNullOrWhiteSpace(inputFolderPath))
            {
                throw new ArgumentException("Input folder path cannot be null or whitespace.", nameof(inputFolderPath));
            }
            
            _inputFolderPath = NormalizePath(inputFolderPath);
        }

        internal static string ReadLocalFile()
        {
            for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir != null; dir = dir.Parent)
            {
                Console.WriteLine($"Checking directory: {dir.FullName}");
                var file = Path.Combine(dir.FullName, Constants.AOC_INPUT_PATH);
                if (File.Exists(file))
                {
                    return File.ReadAllText(file).Trim();
                }
            }

            throw new DirectoryNotFoundException($"Put the input directory path in the '{Constants.AOC_INPUT_PATH}' file in the repo root.");
        }
        internal static string NormalizePath(string inputFolderPath)
        {
            inputFolderPath = Environment.ExpandEnvironmentVariables(inputFolderPath ?? string.Empty);
            if (!Directory.Exists(inputFolderPath))
            {
                Directory.CreateDirectory(inputFolderPath);
            }

            // Normalizes the path format and checks syntax without hitting the disk
            inputFolderPath = Path.GetFullPath(inputFolderPath);

            if (!Directory.Exists(inputFolderPath))
            {
                Directory.CreateDirectory(inputFolderPath);
            }

            return inputFolderPath;
        }



        private string BuildDataFilePath(int day, string name)
        {
            var filename = Path.Combine(_inputFolderPath,
                                        $"Day{day:00}",
                                        $"{name}.txt");
            return filename;
        }

        private void CreateDataFileIfNotExists(string path)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<string> ReadLines(int day, string name)
        {
            try
            {
                var path = BuildDataFilePath(day, name);
                CreateDataFileIfNotExists(path);
                return File.ReadLines(path);
            }
            catch { return null; }
        }

        /// <inheritdoc/>
        public string ReadText(int day, string name)
        {
            var lines = ReadLines(day, name);
            if (lines == null)
            {
                return null;
            }

            var text = string.Join(Environment.NewLine, lines);
            return text?.Length > 0 ? text : null;
        }

    }
}
