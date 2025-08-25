namespace CsharpStudy.Debug;

class Program
{
    static void Main(string[] args)
    {
        var controller = new YukymController();

        Console.WriteLine($"GetTyA() 결과: {controller.GetTyA()}"); // month : '08' = 경오 4국  
        Console.WriteLine($"GetTyB() 결과: {controller.GetTyB()}"); // Hour : '11' : 갑자 5국 
    }
}