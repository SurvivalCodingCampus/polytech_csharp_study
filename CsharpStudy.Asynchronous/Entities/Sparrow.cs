namespace CsharpStudy.Asynchronous.Entities;

public class Sparrow : Bird
{
    public override async Task CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            await Task.Delay(3000);
            TimeElapsed += 3000;
            Console.WriteLine($"({TimeElapsed}ms) 참새 짹짹");
        }

    }
}