namespace CsharpStudy.Async.Problem;

public class Bird
{
    public Bird(int time, string sound)
    {
        Time = time;
        Sound = sound;
    }

    public int Time { get; private set; }
    public string Sound { get; private set; }


    public async Task BirdAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            Console.WriteLine(Sound);
            await Task.Delay(Time);
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Bird bird1 = new Bird(1000, "꾸우");
        Bird bird2 = new Bird(2000, "까악");
        Bird bird3 = new Bird(3000, "짹짹");

        List<Task> list = new List<Task>()
        {
            bird1.BirdAsync(),
            bird2.BirdAsync(),
            bird3.BirdAsync()
        };

        // 모든 작업 동시 실행되도록 
        await Task.WhenAll(list);
    }
}