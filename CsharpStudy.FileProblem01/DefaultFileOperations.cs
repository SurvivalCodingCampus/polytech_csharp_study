namespace CsharpStudy.FileProblem01;

public class DefaultFileOperations : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        string text = File.ReadAllText(sourceFilePath);
        System.IO.File.WriteAllText(destinationFilePath, text);
    }
}