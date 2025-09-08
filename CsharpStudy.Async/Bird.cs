namespace CsharpStudy.Async;

public class Bird
{
    static async Task Bird1()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(1000);
            Console.WriteLine($"꾸우 {i + 1}");
        }
    }
    static async Task Bird2()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(2000);
            Console.WriteLine($"까악 {i + 1}");
        }
    }
    static async Task Bird3()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(3000);
            Console.WriteLine($"짹짹 {i + 1}");
        }
    }
    
    static async Task Main(string[] args)
    {
        Task bird1Task = Bird1();
        Task bird2Task = Bird2();
        Task bird3Task = Bird3();
        
        await Task.WhenAll(bird1Task, bird2Task, bird3Task);
        
        Console.WriteLine("모든 작업 완료");
    }
}