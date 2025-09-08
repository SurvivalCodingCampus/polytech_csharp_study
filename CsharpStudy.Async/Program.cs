namespace CsharpStudy.Async;

class Program
{
    public static async Task Bird1()
    {
        await Task.Delay(1000);
        Console.WriteLine("꾸우");
    }
    
    public static async Task Bird2()
    {
        await Task.Delay(2000);
        Console.WriteLine("까악");
    }
    
    public static async Task Bird3()
    {
        await Task.Delay(3000);
        Console.WriteLine("짹짹");
    }

    public static async Task PrintBirds()
    {
        List<Task> tasks = new List<Task>();

        for (int i = 0; i < 4; i++)
        {
            tasks.Add(Bird1());
            tasks.Add(Bird2());
            tasks.Add(Bird3());
            
            // 가장 먼저 완료 된 작업부터 반환
            await Task.WhenAny(tasks);
        }
        
        // 모든 작업이 모두 끝날 때까지 기다림
        await Task.WhenAll(tasks);
    }

    public static async Task Main()
    {
        await PrintBirds();
    }
}
