namespace CsharpStudy.File;

public class DefaultFileOperations : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
        Console.WriteLine("Copy");
    }
}