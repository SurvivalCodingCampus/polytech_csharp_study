namespace CsharpStudy.Asynchronous.Entities;

public class Crow : Bird
{
    public override async Task CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            await Task.Delay(2000);
            TimeElapsed += 2000;
            Console.WriteLine($"({TimeElapsed}ms) 까마귀 까악");
        }
        
    }
}