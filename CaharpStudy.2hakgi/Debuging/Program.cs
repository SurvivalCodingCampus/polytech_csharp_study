namespace CaharpStudy._2hakgi.Debuging;

public class Program
{
    public static void Main(string[] args)
    {
        var controller = new YukymController();

        Console.WriteLine($"GetTyA() 결과: {controller.GetTyA()}");
        Console.WriteLine($"GetTyB() 결과: {controller.GetTyB()}");
    }
    
}