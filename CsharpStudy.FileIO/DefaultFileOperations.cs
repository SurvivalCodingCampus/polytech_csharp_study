using CsharpStudy.FileIO.Interface;

namespace CsharpStudy.FileIO;

public class DefaultFileOperations : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        String sourceText;

        try
        {
            sourceText = File.ReadAllText(sourceFilePath);
        }
        catch (FileNotFoundException notFoundException)
        {
            Console.WriteLine(
                $"I was looking for {notFoundException.FileName} at {sourceFilePath}, but could not find it.");
            throw;
        }
        catch (OutOfMemoryException outOfMemoryException)
        {
            Console.WriteLine($"The file size is too big to copy.");
            throw;
        }
        catch (UnauthorizedAccessException unauthorizedAccessException)
        {
            Console.WriteLine("Access to the file is denied.");
            throw;
        }
        catch (Exception exception)
        {
            Console.WriteLine("An Exception other than UnauthorizedAccess, OutOfMemory and FileNotFound happened.");
            throw;
        }
        
        File.WriteAllText(destinationFilePath, sourceText ?? String.Empty);
    }
}