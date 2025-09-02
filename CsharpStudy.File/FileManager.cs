namespace ConsoleApp1;

public class FileManager : IFileCopier
{
    public void WriteToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    public string ReadFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        throw new NotImplementedException();
    }
}