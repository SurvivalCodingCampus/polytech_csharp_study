namespace CsharpStudy.Asynchronous.Entities;

public class Parrot : Bird
{
    public override async Task CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            await Task.Delay(1000);
            TimeElapsed += 1000;
            Console.WriteLine($"({TimeElapsed}ms) 앵무 꾸우");
        }
        
    }
}