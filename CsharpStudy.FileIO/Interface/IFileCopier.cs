namespace CsharpStudy.FileIO.Interface;

public interface IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath);
}