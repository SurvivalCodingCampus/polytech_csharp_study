//한 새는 1초마다, 다른 새는 2초마다, 마지막 새는 3초마다 소리를 냅니다
/*요구사항
 각 새의 소리 타이밍을 재현하되, 각 새마다 하나의 비동기 함수를 사용하세요
 각 비동기 함수는 4번만 출력한 후 완료되어야 합니다
 첫 번째 새는 "꾸우" 소리를 냅니다
 두 번째 새는 "까악" 소리를 냅니다
 마지막 새는 "짹짹" 소리를 냅니다
 모든 새소리가 끝나면 프로그램이 종료되어야 합니다*/

namespace JsonSerialization;
public class Practice
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("--- 실행 시작 ---");
        
        Task task1 = Practice.First();
        Task task2 = Practice.Second();
        Task task3 = Practice.Last();
        
        await Task.WhenAll(task1, task2, task3);
    
        Console.WriteLine("--- 실행 종료 ---");
    }
    public static async Task First()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(1000);
            Console.WriteLine("꾸우");
        }
    }
    
    public static async Task Second()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(2000);
            Console.WriteLine("까악");
        }
        
    }
    
    public static async Task Last()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(3000);
            Console.WriteLine("짹짹");
        }
    }
}