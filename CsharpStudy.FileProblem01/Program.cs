namespace CsharpStudy.FileProblem01;

class Program
{
    static void Main(string[] args)
    {
        string sourceFilePath = "firsttext.txt";
        string destinationFilePath = "copytext.txt";

        DefaultFileOperations copy = new DefaultFileOperations();

        try
        {
            copy.CopyFile(sourceFilePath, destinationFilePath);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("복사할 파일이 없습니다.");
        }
    }
}