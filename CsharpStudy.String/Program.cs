using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace CsharpStudy.String;

class Program
{
    static void Main(string[] args)
    {
        // FIRST OF ALL :: string is IMMUTABLE.
        // You will get a new string each time you concatenate strings, Meaning potential performance impacts.
        // So use StringBuilder instead for situation frequently changing words and phrases. 
        
        // '+' operator for concatenate.
        string s1 = "Hello" + "World";
        Console.WriteLine(s1);
        
        // formatted string.
        string name1 = "철수";
        int age1 = 31;
        string s2 = $"안녕하세요, {name1}님. 저는 나이가 {age1}세 입니다.";
        Console.WriteLine(s2);
        
        // String subtraction.
        string s3 = "HELLO";
        Console.WriteLine(s3.Substring(0, 2));
        Console.WriteLine(s3.Substring(2));         // From index 2 to the end.
        
        // String replacement.
        string s4 = "HELLO";
        Console.WriteLine(s4.Replace("LL", "XX"));  // Search "LL" and replace it with "XX".
        
        // String split. (into a list)
        string s5 = "HELLO";
        string[] s5Split = s5.Split(", ");          // Split a string for each ',' met.
        foreach (string s in s5Split)
        {
            Console.WriteLine(s);
        }
        
        // Case-shifting.
        string s6 = "HELLO";
        Console.WriteLine(s6.ToLower());            // ToUpper() vice versa.

        // Trimming.
        string s15 = "  Java and JavaScript  ";
        Console.WriteLine(s15.ToUpper());               // return "  JAVA AND JAVASCRIPT  " (without quotes)
        Console.WriteLine(s15.ToLower());               // return "  java and javascript  " (without quotes)
        Console.WriteLine(s15.Trim());                  // return "Java and JavaScript" (without quotes)
        Console.WriteLine(s15.Replace("and", "or"));    // return "  Java or JavaScript  " (without quotes)
        
        // Length of string
        string s7 = "Hello, world.";
        int s7Length = s7.Length;
        Console.WriteLine(s7Length);
        
        string s8 = "";                             // Empty string
        Console.WriteLine(s8.Length);               // return 0.
        
        // Null, Empty, White check for string
        string s9 = null;
        string s10 = "";
        string s11 = " ";
        string s12 = "hello";
        string s13 = " \t\n ";

        // IsNullOrEmpty()
        Console.WriteLine(string.IsNullOrEmpty(s9));
        Console.WriteLine(string.IsNullOrEmpty(s10));       // No character exist; return true.
        Console.WriteLine(string.IsNullOrEmpty(s11));       // Whitespace is character; return false.
        Console.WriteLine(string.IsNullOrEmpty(s12));
        
        // IsNullOrWhitespace()
        Console.WriteLine(string.IsNullOrWhiteSpace(s9));
        Console.WriteLine(string.IsNullOrWhiteSpace(s10));
        Console.WriteLine(string.IsNullOrWhiteSpace(s11));
        Console.WriteLine(string.IsNullOrWhiteSpace(s12));
        Console.WriteLine(string.IsNullOrWhiteSpace(s13));       // return true.
        
        // String searching
        string s14 = "Java and javaScript";         // WUT..?
        Console.WriteLine(s14.Contains("Java"));                // return true.
        Console.WriteLine(s14.EndsWith("Java"));                // return false.
        Console.WriteLine(s14.IndexOf("Java"));                 // Can find "Java" at index 0; return 0.
        Console.WriteLine(s14.LastIndexOf("Java"));             // The Last "Java" found is at index 9; return 9.
        
        
        // StringBuilder is MUTABLE
        // You should check the way StringBuilder in the site or docs.
        // There are many overriding methods for this.
        // Check this out >>> https://learn.microsoft.com/ko-kr/dotnet/standard/base-types/stringbuilder
        // Examples below are ones of the usages:
        StringBuilder sb1 =  new StringBuilder();
        
        // Append(string)
        sb1.Append("C#, ");
        Console.WriteLine(sb1);      // Return "C#, ". (without quotes)
        sb1.Length = 0;                 // Clearing the StringBuilder.
        
        // AppendFormat(Formatted string with variable slots, slot1, slot2, ...)
        int num1 = 1;
        float num2 = 2.2f;
        string sNum3 = "ABC";
        sb1.AppendFormat("Three variables are put : {0}, {1}, {2}", num1, num2, sNum3);
        Console.WriteLine(sb1); // Return "Three variables are put : 1, 2.2, ABC". (without quotes)

        // Insert(startIndex, string to insert, [how many times?])
        string initialValue = "--[]--";
        StringBuilder sb2 = new StringBuilder(initialValue);
        string xyz = "xyz";
        sb2.Insert(3, xyz, 3);
        Console.WriteLine(sb2);     // Return "--[xyzxyzxyz]--". (without quotes)

        // Remove(startIndex, length)
        StringBuilder sb3 = new StringBuilder("You have selected Microsoft Sam as the default computer voice.");
        sb3.Remove(4, 5);       // "have " erased.
        Console.WriteLine(sb3); // Return "You selected Microsoft Sam as the default computer voice.". (w/o quotes)

        // Replace(old-characters, new-characters)
        StringBuilder sb4 = new StringBuilder("The quick brown fox jumped over the lazy dog.");
        sb4.Replace("quick", "slow");
        sb4.Replace("lazy", "woke-up");
        Console.WriteLine(sb4); // Return "The slow brown fox jumped over the woke-up dog.". (without quotes)
        
        // Method chaining
        // Recursively call methods returning the reference of themselves.
        // Example below is method chaining by calling multiple Append().
        StringBuilder sb5 = new StringBuilder();
        sb5.Append("No, ").Append("No. ").Append("I said \"No.\"");
        Console.WriteLine(sb5);     // Return "No, No. I said "No."". (w/o the outside quotes)

        // Reference equality check among strings.
        string str1 = "Hello";
        string str2 = "Hello";
        string str3 = new string(new char[]{'h', 'e', 'l', 'l', 'o'});
        string str4 = "Hel" + "lo";
        string str5 = "Hel" + GetLo();

        Console.WriteLine(Object.ReferenceEquals(str1, str2));      // Return true.
        Console.WriteLine(Object.ReferenceEquals(str1, str3));      // Return false.
        Console.WriteLine(Object.ReferenceEquals(str1, str4));      // Return true.
        Console.WriteLine(Object.ReferenceEquals(str1, str5));      // Return false.
        
        // Accessor(getter)
        string river = "river";
        string uppercased = river.ToUpper();    // ToUpper() is Accessor; Will NOT modify the original.
        Console.WriteLine($"{river}, {uppercased}");    // "river, RIVER"
        
        // Mutator(setter)
        Rectangle box = new Rectangle(5, 10,60, 40);
        box.Inflate(25, 30);      // Inflate() is Mutator; Original value will be changed.
        Console.WriteLine($"{box.X}, {box.Y}, {box.Width}, {box.Height}");
        
        // Code performance test by using Stopwatch class.
        // You should make instance and Start() at the start of the codes to see the elapsed time, actually.
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // This will be painful to performance.
        // Not sure how much time needed.
        // var text = string.Empty;
        // for (int i = 0; i < 1000000; i++)
        // {
        //     text += i.ToString();
        // }
        
        // StringBuilder's work is much lighter than string's.
        // var builder = new StringBuilder();
        // for (int j = 0; j < 1000000; j++)
        // {
        //     builder.Append(j);
        // }
        
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);   // ElapsedMilliseconds property to show time elapsed in ms.
    }

    public static string GetLo() => "lo";
}