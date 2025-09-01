namespace CshapStudy.File;

public interface IFileCopier
{
     public void CopyFile(string sourceFilePath, string destinationFilePath);
}

public class DefaultFileOperations : IFileCopier
{
     // 월본 파일 경로, 복사할 파일 경로
     public void CopyFile(string sourceFilePath, string destinationFilePath)
     {
          try
          {
               string text = System.IO.File.ReadAllText(sourceFilePath);
               System.IO.File.WriteAllText(destinationFilePath, text);
          }
          catch(IOException e)
          {
               Console.WriteLine(e.Message);
               Console.WriteLine("경로를 다시 지정해주세요");
          }
     }
}