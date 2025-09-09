using System.Text;

namespace CsharpStudy.File.Tests;
using System.IO;

public class FileCopierTests : IDisposable
{
    private readonly string _testDirectory;
    private readonly FileCopier _fileCopier;

    public FileCopierTests()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"FileCopierTests_{Guid.NewGuid()}");
        Directory.CreateDirectory(_testDirectory);
        _fileCopier = new FileCopier();
    }

    public void Dispose()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }

    [Test]
    public void 복사한파일의_내용은_복사할파일의_내용과_같다()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "source.txt");
        var destFile = Path.Combine(_testDirectory, "destination.txt");
        var content = "Hello, World!";
        File.WriteAllText(sourceFile, content);

        // Act
        _fileCopier.CopyFile(sourceFile, destFile);

        // Assert
        Assert.True(File.Exists(destFile));
        Assert.AreEqual(content, File.ReadAllText(destFile));
    }

    [Test]
    public void 내용이_바어있는_파일도_복사할_수_있다()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "empty.txt");
        var destFile = Path.Combine(_testDirectory, "empty_copy.txt");
        File.WriteAllText(sourceFile, "");

        // Act
        _fileCopier.CopyFile(sourceFile, destFile);

        // Assert
        Assert.True(File.Exists(destFile));
        Assert.AreEqual("", File.ReadAllText(destFile));
    }

    [Test]
    public void 복사한파일의_내용은_복사할파일의_바이트_수가_같다()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "binary.dat");
        var destFile = Path.Combine(_testDirectory, "binary_copy.dat");
        var binaryData = new byte[] { 0xFF, 0x00, 0xAA, 0x55, 0x12, 0x34 };
        File.WriteAllBytes(sourceFile, binaryData);

        // Act
        _fileCopier.CopyFile(sourceFile, destFile);

        // Assert
        Assert.True(File.Exists(destFile));
        Assert.AreEqual(binaryData, File.ReadAllBytes(destFile));
    }

    [Test]
    public void CopyFile_LargeFile_CopiesCorrectly()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "large.txt");
        var destFile = Path.Combine(_testDirectory, "large_copy.txt");
        var largeContent = new string('A', 1_000_000); // 10KB of 'A' characters
        File.WriteAllText(sourceFile, largeContent);

        // Act
        _fileCopier.CopyFile(sourceFile, destFile);

        // Assert
        Assert.True(File.Exists(destFile));
        Assert.AreEqual(largeContent, File.ReadAllText(destFile));
    }

    [Test]
    public void CopyFile_OverwriteExistingFile_OverwritesSuccessfully()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "source.txt");
        var destFile = Path.Combine(_testDirectory, "destination.txt");
        File.WriteAllText(sourceFile, "New content");
        File.WriteAllText(destFile, "Old content");

        // Act
        _fileCopier.CopyFile(sourceFile, destFile);

        // Assert
        Assert.AreEqual("New content", File.ReadAllText(destFile));
    }

    [Test]
    public void CopyFile_NonExistentSourceFile_ThrowsFileNotFoundException()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "nonexistent.txt");
        var destFile = Path.Combine(_testDirectory, "destination.txt");

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => _fileCopier.CopyFile(sourceFile, destFile));
    }

    // [Test]
    // public void CopyFile_NullSourcePath_ThrowsArgumentNullException()
    // {
    //     // Arrange
    //     var destFile = Path.Combine(_testDirectory, "destination.txt");
    //
    //     // Act & Assert
    //     Assert.Throws<ArgumentNullException>(() => _fileCopier.CopyFile(null!, destFile));
    // }

    [Test]
    public void CopyFile_EmptySourcePath_ThrowsArgumentException()
    {
        // Arrange
        var destFile = Path.Combine(_testDirectory, "destination.txt");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _fileCopier.CopyFile("", destFile));
    }


    [Test]
    public void CopyFile_InvalidSourcePath_ThrowsDirectoryNotFoundException()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "nonexistent_folder", "source.txt");
        var destFile = Path.Combine(_testDirectory, "destination.txt");

        // Act & Assert
        Assert.Throws<DirectoryNotFoundException>(() => _fileCopier.CopyFile(sourceFile, destFile));
    }

    [Test]
    public void CopyFile_InvalidDestinationPath_ThrowsDirectoryNotFoundException()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "source.txt");
        var destFile = Path.Combine(_testDirectory, "nonexistent_folder", "destination.txt");
        File.WriteAllText(sourceFile, "content");

        // Act & Assert
        Assert.Throws<DirectoryNotFoundException>(() => _fileCopier.CopyFile(sourceFile, destFile));
    }
    
    [Test]
    public void CopyFile_UnicodeContent_PreservesEncoding()
    {
        // Arrange
        var sourceFile = Path.Combine(_testDirectory, "unicode.txt");
        var destFile = Path.Combine(_testDirectory, "unicode_copy.txt");
        var unicodeContent = "Hello 안녕하세요 こんにちは 🌟";
        File.WriteAllText(sourceFile, unicodeContent, Encoding.UTF8);

        // Act
        _fileCopier.CopyFile(sourceFile, destFile);

        // Assert
        Assert.True(File.Exists(destFile));
        Assert.AreEqual(unicodeContent, File.ReadAllText(destFile, Encoding.UTF8));
    }
}