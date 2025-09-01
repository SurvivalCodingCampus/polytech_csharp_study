namespace CsharpStudy.FileProblem01;

public interface IFileCopier
{
    void CopyFile(string sourceFilePath, string destinationFilePath);
    // 원본 파일 경로를 복사할 파일 경로에 복사하기 
}