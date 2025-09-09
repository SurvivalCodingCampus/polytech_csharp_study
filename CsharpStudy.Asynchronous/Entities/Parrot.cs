namespace CsharpStudy.Asynchronous.Entities;

public class Parrot : Bird
{
    public override async Task CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            Console.WriteLine($"({TimeElapsed}ms) 앵무 꾸우");
            TimeElapsed += 1000;
            await Task.Delay(1000);
        }
        
    }
}