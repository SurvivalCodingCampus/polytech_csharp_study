namespace CsharpStudy.Exception_File;

class Program
{
    static void Main(string[] args)
    {
        string? numString = null;
        // FormatException 발생
        // int.Parse()는 정수 문자열만 받아들임

        try
        {
            int num=int.Parse(numString);
            Console.WriteLine(num);
        }
        catch (ArgumentNullException argNull)
        {
            Console.WriteLine("값이 null 입니다.");
        }
        catch (FormatException notInt)
        {
            Console.WriteLine("값이 정수가 아닙니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("예상치 못 한 오류 : " + ex.Message);
        }
        finally
        {
            numString = "0";
        }
    }
}