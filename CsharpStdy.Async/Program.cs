namespace CsharpStdy.Async;

class Program
{
    static async Task BirdSound(string sound, int interval)
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(sound);
            await Task.Delay(interval);
        }
    }
    static async Task Main(string[] args)
    {
        Task bird1 = BirdSound("꾸우", 1000);
        Task bird2 = BirdSound("까악", 2000);
        Task bird3 = BirdSound("짹짹", 3000);
        
        await Task.WhenAll(bird1, bird2, bird3);

        Console.WriteLine("모든 새소리가 끝나면 프로그램이 종료");
    }
}