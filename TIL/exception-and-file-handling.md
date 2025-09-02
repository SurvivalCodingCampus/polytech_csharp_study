# C# Exception 처리와 파일 처리 완전 가이드

## 1. Exception이란 무엇인가?

### Exception의 정의
`Exception` 클래스는 .NET에서 **애플리케이션 실행 중에 발생하는 오류를 나타내는** 기본 클래스입니다.

### Exception이 필요한 이유
1. **예측 불가능한 상황 처리**: 파일이 존재하지 않거나, 네트워크 연결이 끊어지는 등의 상황
2. **프로그램 안정성**: 예외 처리 없이는 애플리케이션이 비정상 종료될 수 있음
3. **디버깅 정보 제공**: 오류 발생 위치와 원인을 정확히 파악 가능
4. **우아한 실패 처리**: 사용자에게 적절한 오류 메시지 제공

### Exception 클래스의 주요 속성
```csharp
public class Exception
{
    public string Message { get; }           // 예외 설명 메시지
    public string StackTrace { get; }        // 호출 스택 정보
    public Exception InnerException { get; } // 원인이 된 내부 예외
    public string Source { get; set; }       // 예외를 발생시킨 객체명
}
```

## 2. IOException: 입출력 예외의 핵심

### IOException이란?
`IOException`은 **스트림, 파일, 디렉터리에 접근하는 동안 발생하는 예외들의 기본 클래스**입니다.

### IOException이 발생하는 상황
- 파일을 읽거나 쓰는 중 오류 발생
- 네트워크 스트림에서 연결 문제 발생
- 디스크 공간 부족
- 파일이 다른 프로세스에 의해 잠겨있는 경우

### IOException의 주요 파생 예외들
```csharp
IOException (기본 I/O 예외)
├── DirectoryNotFoundException     // 디렉터리를 찾을 수 없음
├── EndOfStreamException          // 스트림의 끝에 도달
├── FileNotFoundException         // 파일을 찾을 수 없음
├── FileLoadException            // 파일 로드 실패
└── PathTooLongException         // 경로가 너무 긺
```

### IOException 처리 예제
```csharp
try
{
    string content = File.ReadAllText("example.txt");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"파일을 찾을 수 없습니다: {ex.FileName}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"파일 접근 권한이 없습니다: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"파일 I/O 오류: {ex.Message}");
}
```

## 3. System.IO.File 클래스

### File 클래스 특징
- **정적 메서드만 제공**하는 유틸리티 클래스
- 단일 파일에 대한 **생성, 복사, 삭제, 이동, 열기** 작업 수행
- 모든 메서드는 파일 경로(string)를 매개변수로 받음

### 주요 파일 조작 메서드

#### 파일 생성 및 쓰기
```csharp
// 텍스트 파일 생성/쓰기
File.CreateText(string path)                    // UTF-8 텍스트 파일 생성
File.WriteAllText(string path, string content) // 텍스트 전체 쓰기
File.WriteAllLines(string path, string[] lines) // 라인별로 쓰기
File.WriteAllBytes(string path, byte[] bytes)   // 바이트 배열 쓰기

// 예제
File.WriteAllText("example.txt", "Hello World!");
```

#### 파일 읽기
```csharp
// 텍스트 파일 읽기
string File.ReadAllText(string path)           // 전체 텍스트 읽기
string[] File.ReadAllLines(string path)        // 모든 줄을 배열로 읽기
byte[] File.ReadAllBytes(string path)          // 바이트 배열로 읽기
StreamReader File.OpenText(string path)        // 텍스트 파일 스트림 열기

// 예제
string content = File.ReadAllText("example.txt");
string[] lines = File.ReadAllLines("example.txt");
```

#### 파일 정보 및 관리
```csharp
bool File.Exists(string path)                  // 파일 존재 확인
void File.Copy(string source, string dest)     // 파일 복사
void File.Move(string source, string dest)     // 파일 이동/이름변경
void File.Delete(string path)                  // 파일 삭제
DateTime File.GetCreationTime(string path)     // 생성 시간 조회
DateTime File.GetLastWriteTime(string path)    // 마지막 수정 시간 조회

// 예제
if (File.Exists("example.txt"))
{
    File.Copy("example.txt", "backup.txt");
}
```

### File 클래스에서 발생하는 주요 예외
```csharp
try
{
    File.WriteAllText("C:\\protected\\file.txt", "content");
}
catch (UnauthorizedAccessException)
{
    // 접근 권한 없음
}
catch (DirectoryNotFoundException)
{
    // 디렉터리가 존재하지 않음
}
catch (PathTooLongException)
{
    // 경로가 너무 긺
}
catch (IOException)
{
    // 기타 I/O 오류
}
```

## 4. System.IO.FileStream 클래스

### FileStream 클래스 특징
- **Stream 기본 클래스를 상속**받는 파일 전용 스트림
- **동기/비동기** 읽기 및 쓰기 작업 지원
- **세밀한 제어**가 가능 (버퍼 크기, 접근 권한, 공유 모드 등)

### 주요 생성자
```csharp
// 기본 생성자들
FileStream(string path, FileMode mode)
FileStream(string path, FileMode mode, FileAccess access)
FileStream(string path, FileMode mode, FileAccess access, FileShare share)
FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)

// FileMode 열거형
FileMode.Create        // 새 파일 생성 (기존 파일 덮어쓰기)
FileMode.CreateNew     // 새 파일 생성 (기존 파일 있으면 예외)
FileMode.Open          // 기존 파일 열기
FileMode.OpenOrCreate  // 파일이 있으면 열고, 없으면 생성
FileMode.Append        // 파일 끝에 추가
FileMode.Truncate      // 기존 파일을 0바이트로 자름
```

### 주요 메서드
```csharp
// 읽기/쓰기
int Read(byte[] buffer, int offset, int count)
void Write(byte[] buffer, int offset, int count)
Task<int> ReadAsync(byte[] buffer, int offset, int count)
Task WriteAsync(byte[] buffer, int offset, int count)

// 스트림 조작
long Seek(long offset, SeekOrigin origin)  // 스트림 위치 이동
void Flush()                               // 버퍼 플러시
void SetLength(long length)                // 스트림 길이 설정
```

### 주요 속성
```csharp
bool CanRead            // 읽기 가능 여부
bool CanWrite           // 쓰기 가능 여부
bool CanSeek            // 탐색 가능 여부
long Length             // 스트림 길이
long Position           // 현재 위치
string Name             // 파일 경로
```

### FileStream 사용 예제
```csharp
// 파일 쓰기 예제
using (var fs = new FileStream("data.bin", FileMode.Create))
{
    byte[] data = Encoding.UTF8.GetBytes("Hello FileStream!");
    fs.Write(data, 0, data.Length);
    fs.Flush();
}

// 파일 읽기 예제
using (var fs = new FileStream("data.bin", FileMode.Open))
{
    byte[] buffer = new byte[fs.Length];
    int bytesRead = fs.Read(buffer, 0, buffer.Length);
    string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
}

// 비동기 읽기 예제
using (var fs = new FileStream("large.dat", FileMode.Open))
{
    byte[] buffer = new byte[1024];
    int bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length);
}
```

## 5. File vs FileStream 비교

| 특징 | File | FileStream |
|------|------|------------|
| **사용 방식** | 정적 메서드 | 인스턴스 생성 필요 |
| **메모리 효율성** | 전체 파일을 메모리에 로드 | 스트림 방식으로 부분 처리 |
| **대용량 파일** | 부적합 (메모리 부족 위험) | 적합 (청크 단위 처리) |
| **사용 편의성** | 간단한 한 줄 코드 | using 블록과 예외 처리 필요 |
| **성능 제어** | 제한적 | 버퍼 크기, 접근 모드 제어 가능 |
| **비동기 지원** | 제한적 | 완전 지원 |

### 언제 무엇을 사용할까?

**File 클래스 사용 시기:**
- 작은 파일 (수 MB 이하)
- 간단한 읽기/쓰기 작업
- 프로토타입이나 간단한 스크립트

**FileStream 사용 시기:**
- 대용량 파일 처리
- 스트림 방식의 데이터 처리가 필요한 경우
- 세밀한 I/O 제어가 필요한 경우
- 비동기 처리가 중요한 경우

## 6. 실제 적용: FileCopier 클래스 개선

현재 FileCopier 클래스의 예외 처리를 개선해보겠습니다:

```csharp
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
            throw new ArgumentException("소스 경로는 null이거나 빈 문자열일 수 없습니다.", nameof(sourcePath));
        
        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("대상 경로는 null이거나 빈 문자열일 수 없습니다.", nameof(destination));
    }
}
```

## 7. 베스트 프랙티스

### Exception 처리 가이드라인
1. **구체적인 예외부터 처리**: `catch` 블록은 구체적인 예외부터 일반적인 예외 순으로 배치
2. **예외 정보 보존**: `InnerException`을 활용하여 원본 예외 정보 보존
3. **리소스 정리**: `using` 문 또는 `try-finally`로 리소스 해제 보장
4. **로깅**: 예외 발생 시 적절한 로깅으로 디버깅 정보 제공

### 파일 처리 가이드라인
1. **항상 using 문 사용**: FileStream 등 IDisposable 리소스는 반드시 해제
2. **적절한 버퍼 크기**: 64KB~1MB 정도의 버퍼 크기 권장
3. **비동기 처리 고려**: 대용량 파일이나 네트워크 파일의 경우 async/await 사용
4. **입력 검증**: 파일 경로와 매개변수 유효성 검사 필수

이러한 예외 처리와 파일 처리 개념을 숙지하면 더 안정적이고 효율적인 C# 애플리케이션을 개발할 수 있습니다.