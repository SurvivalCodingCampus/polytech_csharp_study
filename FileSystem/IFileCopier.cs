namespace FileSystem;

public interface IFileCopier
{
    void Copy(string sourceFilePath, string destinationFilePath);
}