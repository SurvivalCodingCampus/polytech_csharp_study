namespace CsharpStudy.FileIO.Interface;

public interface IFileCopier
{
    void CopyFile(string sourceFilePath, string destinationFilePath);
}