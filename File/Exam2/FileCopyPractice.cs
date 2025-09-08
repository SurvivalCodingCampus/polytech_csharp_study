namespace File.Exam2;

public interface IFileCopier
{
    void CopyFile(string sourceFilePath, string destinationFilePath);
}

public class FileCopier : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        if (string.IsNullOrWhiteSpace(sourceFilePath))
        {
            throw new ArgumentException("원본 소스 경로가 잘못 되었습니다");
        }

        if (string.IsNullOrWhiteSpace(destinationFilePath))
        {
            throw new ArgumentException("타겟 소스 경로가 잘못 되었습니다");
        }
        
        string text=System.IO.File.ReadAllText(sourceFilePath);
        
        System.IO.File.WriteAllText(destinationFilePath, text);
    }
}

public class FileCopyPractice
{
    static void Main(String[] args)
    {
        FileCopier fileCopier = new FileCopier();
        fileCopier.CopyFile("source.txt", "destination.txt");
    }
}