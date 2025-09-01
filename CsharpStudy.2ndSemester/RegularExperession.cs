namespace CsharpStudy._2ndSemester;

public class RegularExperession
{
    public static void Main(String[] args)
    {
        String s = "1,";
        for (int i = 2; i <= 100; i++)
        {
            s += i.ToString();
            s += ',';
        }
        
        String [] words =  s.Split(',');
    }
}