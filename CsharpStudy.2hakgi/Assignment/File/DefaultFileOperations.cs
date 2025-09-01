namespace CsharpStudy._2hakgi.Assignment.File;

public class DefaultFileOperations : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        try
        {
            string text = System.IO.File.ReadAllText(sourceFilePath);
            System.IO.File.WriteAllText(destinationFilePath, text);
            Console.WriteLine("복사가 완료되었습니다.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("파일이 존재하지 않습니다.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("경로가 올바르지 않습니다.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("파일 접근 권한이 없습니다.");
        }
        catch (System.Exception e) // 모든 나머지 예외
        {
            Console.WriteLine(e.Message);
        }
    }
}