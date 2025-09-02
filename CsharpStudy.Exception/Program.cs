namespace CsharpStudy.Exception;

class Program
{
    static void Main(string[] args)
    {
        PracticeProblem_1();
    }

    static void PracticeProblem_1()
    {
        var numString = "10.5";

        int num = int.Parse(numString);
    }

    static void PracticeProblem_2()
    {
        int num = 0;
        
        try
        {
            num = int.Parse("10.5");
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.GetType().Name);
        }
       
    }
}

