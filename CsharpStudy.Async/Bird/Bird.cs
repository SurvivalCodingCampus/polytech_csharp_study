namespace CsharpStudy.Async.Bird;

public class Bird
{
    public Bird(int time, string sound)
    {
        Time = time;
        Sound = sound;
    }

    public int Time { get; private set; }
    public string Sound { get; private set; }

    public async Task CryAsync()
    {
        while (true)
        {
            Console.WriteLine(Sound);
            await Task.Delay(Time);
        }
    }

    static async Task Main(string[] args)
    {
        Bird bird1 = new Bird(1000, "꾸욱");
        Bird bird2 = new Bird(2000, "까악");
        Bird bird3 = new Bird(3000, "꽥꽥");
        
        // 동시 출발
        bird1.CryAsync();
        bird2.CryAsync();
        bird3.CryAsync();

        // await Task.WhenAll(birds.Select(bird => bird.CryAsync()));
        
        // 10초 후에 다물어
        await Task.Delay(10000);
    }
}