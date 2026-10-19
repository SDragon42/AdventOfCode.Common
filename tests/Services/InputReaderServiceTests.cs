using System.IO;

namespace AdventOfCode.Common.Tests.Services;

public class InputReaderServiceTests
{
    private static string CreateTemporaryFolder()
    {
        var path = Path.Combine(Path.GetTempPath(), $"AdventOfCode.Common.Tests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(path);
        return path;
    }


    [Fact]
    public void ReadLocalFile_ConfigurationFileExists_ReturnsTrimmedPath()
    {
        var configurationFile = Path.Combine(AppContext.BaseDirectory, Constants.AOC_INPUT_PATH);
        var existingConfiguration = File.Exists(configurationFile)
            ? File.ReadAllText(configurationFile)
            : null;
        try
        {
            File.WriteAllText(configurationFile, "  input-folder" + Environment.NewLine);

            Assert.Equal("input-folder", InputReaderService.ReadLocalFile());
        }
        finally
        {
            if (existingConfiguration is null)
            {
                File.Delete(configurationFile);
            }
            else
            {
                File.WriteAllText(configurationFile, existingConfiguration);
            }
        }
    }

    [Fact]
    public void NormalizePath_RelativeSegments_ReturnsFullPathAndCreatesDirectory()
    {
        var temporaryFolder = CreateTemporaryFolder();
        var inputFolder = Path.Combine(temporaryFolder, "nested", "..", "inputs");
        try
        {
            var normalizedPath = InputReaderService.NormalizePath(inputFolder);

            Assert.Equal(Path.GetFullPath(inputFolder), normalizedPath);
            Assert.True(Directory.Exists(normalizedPath));
        }
        finally
        {
            Directory.Delete(temporaryFolder, true);
        }
    }

    [Fact]
    public void NormalizePath_EnvironmentVariable_ExpandsPath()
    {
        var temporaryFolder = CreateTemporaryFolder();
        var variableName = $"ADVENT_OF_CODE_TEST_{Guid.NewGuid():N}";
        var existingValue = Environment.GetEnvironmentVariable(variableName);
        var inputFolder = Path.Combine($"%{variableName}%", "inputs");
        try
        {
            Environment.SetEnvironmentVariable(variableName, temporaryFolder);

            var normalizedPath = InputReaderService.NormalizePath(inputFolder);

            Assert.Equal(Path.Combine(temporaryFolder, "inputs"), normalizedPath);
            Assert.True(Directory.Exists(normalizedPath));
        }
        finally
        {
            Environment.SetEnvironmentVariable(variableName, existingValue);
            Directory.Delete(temporaryFolder, true);
        }
    }

    [Fact]
    public void Constructor_Default_UsesInputFolderFromLocalFile()
    {
        var inputFolder = CreateTemporaryFolder();
        var configurationFile = Path.Combine(AppContext.BaseDirectory, Constants.AOC_INPUT_PATH);
        var existingConfiguration = File.Exists(configurationFile)
            ? File.ReadAllText(configurationFile)
            : null;
        try
        {
            var dayFolder = Path.Combine(inputFolder, "Day03");
            Directory.CreateDirectory(dayFolder);
            File.WriteAllText(Path.Combine(dayFolder, "sample.txt"), "configured input");
            File.WriteAllText(configurationFile, inputFolder);

            var service = new InputReaderService();

            Assert.Equal(["configured input"], service.ReadLines(3, "sample"));
        }
        finally
        {
            if (existingConfiguration is null)
            {
                File.Delete(configurationFile);
            }
            else
            {
                File.WriteAllText(configurationFile, existingConfiguration);
            }

            Directory.Delete(inputFolder, true);
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Constructor_NullOrWhitespaceInputFolder_ThrowsArgumentException(string? inputFolderPath)
    {
        var exception = Assert.Throws<ArgumentException>(() => new InputReaderService(inputFolderPath!));

        Assert.Equal("inputFolderPath", exception.ParamName);
    }

    [Fact]
    public void Constructor_MissingInputFolder_CreatesFolder()
    {
        var temporaryFolder = CreateTemporaryFolder();
        var inputFolder = Path.Combine(temporaryFolder, "inputs", "nested");
        try
        {
            _ = new InputReaderService(inputFolder);

            Assert.True(Directory.Exists(inputFolder));
        }
        finally
        {
            Directory.Delete(temporaryFolder, true);
        }
    }

    [Fact]
    public void ReadLines_ExistingFile_ReturnsEachLine()
    {
        var inputFolder = CreateTemporaryFolder();
        try
        {
            var dayFolder = Path.Combine(inputFolder, "Day03");
            Directory.CreateDirectory(dayFolder);
            File.WriteAllText(Path.Combine(dayFolder, "sample.txt"), string.Join(Environment.NewLine, "first", "second"));

            var service = new InputReaderService(inputFolder);

            Assert.Equal(["first", "second"], service.ReadLines(3, "sample"));
        }
        finally
        {
            Directory.Delete(inputFolder, true);
        }
    }

    [Fact]
    public void ReadLines_MissingFile_CreatesEmptyFile()
    {
        var inputFolder = CreateTemporaryFolder();
        try
        {
            var service = new InputReaderService(inputFolder);

            Assert.Empty(service.ReadLines(7, "input"));
            Assert.True(File.Exists(Path.Combine(inputFolder, "Day07", "input.txt")));
        }
        finally
        {
            Directory.Delete(inputFolder, true);
        }
    }

    [Fact]
    public void ReadText_ExistingFile_ReturnsTextWithPlatformNewlines()
    {
        var inputFolder = CreateTemporaryFolder();
        try
        {
            var dayFolder = Path.Combine(inputFolder, "Day03");
            Directory.CreateDirectory(dayFolder);
            File.WriteAllText(Path.Combine(dayFolder, "sample.txt"), string.Join(Environment.NewLine, "first", "second"));
            var service = new InputReaderService(inputFolder);

            Assert.Equal(string.Join(Environment.NewLine, "first", "second"), service.ReadText(3, "sample"));
        }
        finally
        {
            Directory.Delete(inputFolder, true);
        }
    }

    [Fact]
    public void ReadText_EmptyInput_ReturnsNull()
    {
        var inputFolder = CreateTemporaryFolder();
        try
        {
            var service = new InputReaderService(inputFolder);

            Assert.Null(service.ReadText(1, "empty"));
        }
        finally
        {
            Directory.Delete(inputFolder, true);
        }
    }
}
