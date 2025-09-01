namespace CsharpStudy.Exception_File;

public interface IFileCopier
{
    void CopyFile(string sourceFilePath, string destinationFilePath);
}