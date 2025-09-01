namespace CsharpStudy.FileIO;

class Program
{
    static void Main(string[] args)
    {
        // string fileName = "SampleText.txt";
        // modify these members to ones suited to your PC.
        var sourcePath = @"C:\_Workplace\polytech_csharp_study\CsharpStudy.FileIO\SampleText.txt";
        var destinationPath = @"C:\_Workplace\polytech_csharp_study\CsharpStudy.FileIO\SampleText_copy.txt";
        
        var dfo = new DefaultFileOperations();
        dfo.CopyFile(sourcePath, destinationPath);
    }
}