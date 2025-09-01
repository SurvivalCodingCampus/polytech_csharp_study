namespace CsharpStudy.File;

public interface IFileCopier
{
    void CopyFile(string sourceFilePath, string destinationFilePath);
}