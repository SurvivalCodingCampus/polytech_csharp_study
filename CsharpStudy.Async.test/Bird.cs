namespace CsharpStudy.Async.test;

public class Bird
{
    private static int REPEAT_NUM = 4; 
    private string sound;
    private int delayTime;

    public int DelayTime
    {
        get => delayTime;
        set => delayTime = value;
    }

    public Bird(string sound, int delayTime)
    {
        this.sound = sound;
        this.delayTime = delayTime;
    }

    public async Task printSound()
    {
        for (int i = 0; i < REPEAT_NUM; i++)
        {
            await Task.Delay(delayTime);
            Console.WriteLine(sound);
        }
    }
}