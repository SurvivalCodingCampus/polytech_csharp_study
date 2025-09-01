namespace CsharpStudy.File;


class Program
{
    static void Main(string[] args)
    {
        
        string source = "text.txt";
        string destination = "text_copy.txt";

        if (!System.IO.File.Exists(source))
        {
            System.IO.File.WriteAllText(source, "Hello World");
            Console.WriteLine("source");
        }
    }
}