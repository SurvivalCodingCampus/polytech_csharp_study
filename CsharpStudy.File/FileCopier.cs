using CsharpStudy.File;

public class FileCopier : IFileCopier
{
    private readonly int bufferSize = 64 * 1024; // 64KB 버퍼

    public void CopyFile(string sourcePath, string destination)
    {
        // 입력 검증
        ValidateInputs(sourcePath, destination);

        try
        {
            using (var source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (var dest = new FileStream(destination, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dest.Write(buffer, 0, bytesRead);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            throw new FileNotFoundException($"소스 파일을 찾을 수 없습니다: {sourcePath}", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new UnauthorizedAccessException($"파일 접근 권한이 없습니다: {ex.Message}", ex);
        }
        catch (DirectoryNotFoundException ex)
        {
            throw new DirectoryNotFoundException($"디렉터리를 찾을 수 없습니다: {ex.Message}", ex);
        }
        catch (IOException ex)
        {
            throw new IOException($"파일 복사 중 I/O 오류가 발생했습니다: {ex.Message}", ex);
        }
    }

    private void ValidateInputs(string sourcePath, string destination)
    {
        if (string.IsNullOrWhiteSpace(sourcePath))
            throw new ArgumentNullException("소스 경로는 null이거나 빈 문자열일 수 없습니다.", nameof(sourcePath));
        
        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentNullException("대상 경로는 null이거나 빈 문자열일 수 없습니다.", nameof(destination));
    }
}