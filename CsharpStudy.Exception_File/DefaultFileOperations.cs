namespace CsharpStudy.Exception_File;
using System.IO;

public class DefaultFileOperations : IFileCopier
{
    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        if (sourceFilePath == destinationFilePath)
        {
            throw new ArgumentException("동일한 이름의 파일이 존재합니다.");
        }
        
        try
        {
            string text = File.ReadAllText(sourceFilePath);
            
            File.WriteAllText(destinationFilePath, text);
            Console.WriteLine("파일 복사 성공");
        }
        catch (FileNotFoundException fileNotFoundException)
        {
            Console.WriteLine("원본 파일을 찾지 못 했습니다.");
        }
        catch(Exception ex)
        {
            Console.WriteLine("예상치 못한 오류 발생 : " + ex.Message);
        }
    }
}