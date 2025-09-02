using CsharpStudy.FileIO.Interface;

namespace CsharpStudy.FileIO;

public class DefaultFileOperations : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        // String sourceText;
        //
        // try
        // {
        //     sourceText = File.ReadAllText(sourceFilePath);
        // }
        // catch (FileNotFoundException notFoundException)
        // {
        //     Console.WriteLine(
        //         $"I was looking for {notFoundException.FileName} at {sourceFilePath}, but could not find it.");
        //     throw;
        // }
        // catch (OutOfMemoryException outOfMemoryException)
        // {
        //     Console.WriteLine($"The file size is too big to copy.");
        //     throw;
        // }
        // catch (UnauthorizedAccessException unauthorizedAccessException)
        // {
        //     Console.WriteLine("Access to the file is denied.");
        //     throw;
        // }
        // catch (Exception exception)
        // {
        //     Console.WriteLine("An Exception other than UnauthorizedAccess, OutOfMemory and FileNotFound happened.");
        //     throw;
        // }
        
        // File.WriteAllText(destinationFilePath, sourceText ?? String.Empty);
        
        
        // Codes below are AI-Recommended ones.
        // I'll leave this code as comments for the comparison.
        
        // Path-checking
        if (string.IsNullOrEmpty(sourceFilePath)) { throw new ArgumentException("Source file's path is null or empty", nameof(sourceFilePath)); }
        if (string.IsNullOrEmpty(destinationFilePath)) { throw new ArgumentException("Destination file's path is null or empty", nameof(destinationFilePath)); }

        try
        {
            // Even AI makes a mistake.; these codes below are not unused.
            // =========================
            // var destDir = Path.GetDirectoryName(destinationFilePath);
            // if (!string.IsNullOrEmpty(destDir))
            // {
            //     Directory.CreateDirectory(destDir);
            // }
            
            // Files inside of 'using' will be disposed, closed or deleted when going outside of 'using' block.
            // So it is still OK even if you don't Close() or Dispose().
            using var src = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var dest =
                new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write,
                    FileShare.None); // Use 'CreateNew' FileMode if you don't want to allow overwriting.
            src.CopyTo(dest);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Source file not found: {sourceFilePath}");
            throw;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Directory not found for source or destination.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
            throw;
        }
        catch (IOException exception)
        {
            // Example 1 : Disk error
            // Example 2 : File already exists (only if you set FileMode to CreateNew)
            Console.WriteLine($"I/O error: {exception.Message}");
            throw;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"FUBAR. Help. Exception: {exception.Message}");
            throw;
        }
    }
}