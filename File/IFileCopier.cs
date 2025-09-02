namespace File;

public interface IFileCopier
{
    //1. 파일을 복사하는 DefaultFileOperations 클래스를 작성하시오
    void CopyFilr(string sourceFilePath, string destinationFilePath);
    //원본 파일 경로와 복사할 파일 경로는 프로그램 실행시 파라미터로 전달되는 것으로 하고 예외처리는 자유롭게
}