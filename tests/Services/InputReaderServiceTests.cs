using System.IO;

namespace AdventOfCode.Common.Tests.Services;

public class InputReaderServiceTests
{
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


    private static string CreateTemporaryFolder()
    {
        var path = Path.Combine(Path.GetTempPath(), $"AdventOfCode.Common.Tests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(path);
        return path;
    }
}
