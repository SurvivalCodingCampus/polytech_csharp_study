using System.Net.Mime;

namespace CaharpStudy._2hakgi.File;

public class DefaultFileOperations : IFileCopier
{
    
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        try
        { 
            string fileContents =System.IO.File.ReadAllText(sourceFilePath); //file읽기
            System.IO.File.WriteAllText(destinationFilePath, fileContents );// 쓰기
            Console.WriteLine("파일이 성공적으로 복사되었습니다.");

        }
        catch (Exception e)
        {
            Console.WriteLine("오류");

        }
    }

    public static void Main(String[] args)
    {
        IFileCopier fileCopier = new DefaultFileOperations();
        string source = "text.txt";
        string destination = "test.txt";
        fileCopier.CopyFile(source, destination);
  
    }
    
    
}