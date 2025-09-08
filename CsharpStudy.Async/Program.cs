namespace CsharpStudy.Async;

class Program
{
    static async Task sec_1()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine("꾸우");
    }

    static async Task sec_2()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        Console.WriteLine("까악");
    }

    static async Task sec_3()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        Console.WriteLine("쨱짹");
    }

    static async Task run()
    {
        await sec_1();
        await sec_1();
        await sec_1();
        await sec_1();
    }

    static async Task run2()
    {
        await sec_2();
        await sec_2();
        await sec_2();
        await sec_2();
    }

    static async Task run3()
    {
        await sec_3();
        await sec_3();
        await sec_3();
        await sec_3();
    }

    static async Task Main(string[] args)
    {
        List<Task> tasks = new List<Task>()
        {
            run(), run2(), run3()
        };

        await Task.WhenAll(tasks);
    }
}