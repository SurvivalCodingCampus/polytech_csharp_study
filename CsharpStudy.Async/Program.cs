namespace CsharpStudy.Async;

class Program
{
    static async Task Bird1()
    {
        for (int i = 0; i < 4; i++)
        {
         await Task.Delay(1000);
            Console.WriteLine("꾸우");
        }
    }

    static async Task Bird2()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(2000);
            Console.WriteLine("까악");
        }
    }

    static async Task Bird3()
    {
        for (int i = 0; i < 4; i++)
        {
            await Task.Delay(3000);
            Console.WriteLine("짹짹");
        }
    }

    static async Task Main(string[] args) 
        {
                Task bird1 = Bird1();
                Task bird2 = Bird2();
                Task bird3 = Bird3();

                await Task.WhenAll(bird1,bird2,bird3); 
        }
}