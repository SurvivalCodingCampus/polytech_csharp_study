namespace CsharpStudy.File;

class Program
{
    static void Main(string[] args)
    {
        FileCopier  fileCopier = new FileCopier();
        
        fileCopier.CopyFile("/Users/mr21/Documents/riderProject/polytech_csharp_study/test.txt", "/Users/mr21/Documents/riderProject/polytech_csharp_study/copy.txt");
    }
}