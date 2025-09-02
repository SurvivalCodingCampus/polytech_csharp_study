namespace Ex;


public class InventoryFullException : Exception
{
    public InventoryFullException() : base("인벤토리가 가득 찼습니다.")
    {
    }

    public InventoryFullException(string message) : base(message)
    {
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        
        var numString = "10.5";
        int num = 0;
        try
        {
            num = int.Parse(numString);
            //SomeError2();
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            num = 0;
        }
        finally
        {
            Console.WriteLine(num);
        }
        IFileCopier copier = new FileCopier();
            string sourcePath = "text.txt";
            string destinationPath = "text1.txt";
                
            File.Copy(sourcePath, destinationPath);
            Console.WriteLine("복사완료");
        
        // File.Copy("/Users/mr66/Desktop/cshap/polytech_csharp_study/Ex/bin/Debug/net8.0/text.txt","/Users/mr66/Desktop/cshap/polytech_csharp_study/Ex/bin/Debug/net8.0/text1.txt",true);

    }
}