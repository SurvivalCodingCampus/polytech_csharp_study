namespace CsharpStudy.FileProblem01.Exam02;

public interface IFileCopier
{
    void CopyFile(string sourceFilePath, string destinationFilePath);
}

public class FileCopier : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        // 원본 소스 잘못 된 경우
        if (string.IsNullOrWhiteSpace(sourceFilePath))
        {
            throw new ArgumentException("원본 소스 경로가 잘못 되었습니다");
        }

        // 원본 소스 잘못 된 경우
        if (string.IsNullOrWhiteSpace(destinationFilePath))
        {
            throw new ArgumentException("타겟 소스 경로가 잘못 되었습니다");
        }

        // 읽어서
        string text = System.IO.File.ReadAllText(sourceFilePath);

        // 쓰자
        System.IO.File.WriteAllText(destinationFilePath, text);
    }
}

public class FileCopyExam
{
    static void Main(string[] args)
    {
        FileCopier fileCopier = new FileCopier();
        fileCopier.CopyFile("source.txt", "destination.txt");
    }
}