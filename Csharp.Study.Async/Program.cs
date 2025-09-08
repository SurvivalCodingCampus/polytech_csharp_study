namespace Csharp.Study.Async;

class Program
{
    static async Task Bird1()
    {
        for (int i = 1; i <= 4; i++)
        {
            await Task.Delay(1000);
            Console.WriteLine($"첫번째 ({i}/4): 꾸우");
        }
    }

    static async Task Bird2()
    {
        for (int i = 1; i <= 4; i++)
        {
            await Task.Delay(2000);
            Console.WriteLine($"두번째 ({i}/4): 까악");
        }
    }
    
    static async Task Bird3()
    {
        for (int i = 1; i <= 4; i++)
        {
            await Task.Delay(3000);
            Console.WriteLine($"세번째 ({i}/4): 짹짹");
        }
    }

    static async Task BirdsSing()
    {
        List<Task> tasks = new List<Task>
        {
            Bird1(), Bird2(), Bird3()
        };

        await Task.WhenAll(tasks);
    }
    
    static async Task Main()
    {
        await BirdsSing();
        Console.WriteLine("");
    }
}