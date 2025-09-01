namespace CsharpStudy.FileRW;

public class Program
{
    public interface IFileCopier
    {
        void CopyFile(string sourceFilePath, string destinationFilePath);
    }
    
    
}
