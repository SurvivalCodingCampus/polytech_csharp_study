using System.Diagnostics;

namespace CsharpStudy.Asset;

public class TimeMeasurement
{
    static void Main1()
    {
        // Stopwatch 객체 생성 및 시작
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // 측정하려는 코드 블록
        
        // Stopwatch 정지
        stopwatch.Stop();
        
        // 경과 시간 출력
        Console.WriteLine($"경과 시간: {stopwatch.Elapsed.TotalMilliseconds}ms");
        
    }
}
