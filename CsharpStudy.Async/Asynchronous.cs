namespace CsharpStudy.Async;

using System;
using System.Threading.Tasks;

public class Asynchronous
{
    // 첫번째 새
    static async Task FirstBirdAsync()
    {
        for (int i = 1; i <= 4; i++)
        {
            // await는 Task가 끝났는지 확인하는 역할
            // Task는 확인을 받고 Task객체로 반환
            await Task.Delay(1000); // 1초간 대기
            Console.WriteLine($"첫째 새: 꾸우 ({i}/4)");
        }
    }
    
    // 두번째 새
    static async Task SecondBirdAsync()
    {
        for (int i = 1; i <= 4; i++)
        {
            await Task.Delay(2000); // 2초간 대기
            Console.WriteLine($"둘째 새: 까악 ({i}/4)");
        }
    }
    
    // 마지막 새
    static async Task ThirdBirdAsync()
    {
        for (int i = 1; i <= 4; i++)
        {
            await Task.Delay(3000); // 3초간 대기
            Console.WriteLine($"마지막 새: 짹짹 ({i}/4)");
        }
    }
    
    static async Task Main()
    {
        // 비동기 작업으로 시작
        var t1 = FirstBirdAsync();
        var t2 = SecondBirdAsync();
        var t3 = ThirdBirdAsync();
        
        // 모든 작업이 끝날 때까지 대기
        await Task.WhenAll(t1, t2, t3);
        
        // 모든 작업이 완료되면 실행
        Console.WriteLine("프로그램을 종료합니다.");
    }
}