using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace CsharpStudy.String;

internal class Program
{
    private static void Main(string[] args)
    {
        // FIRST OF ALL :: string is IMMUTABLE.
        // You will get a new string each time you concatenate strings, Meaning potential performance impacts.
        // So use StringBuilder instead for situation frequently changing words and phrases. 

        // '+' operator for concatenate.
        var s1 = "Hello" + "World";
        Console.WriteLine(s1);

        // formatted string.
        var name1 = "철수";
        var age1 = 31;
        var s2 = $"안녕하세요, {name1}님. 저는 나이가 {age1}세 입니다.";
        Console.WriteLine(s2);

        // String subtraction.
        var s3 = "HELLO";
        Console.WriteLine(s3.Substring(0, 2));
        Console.WriteLine(s3.Substring(2)); // From index 2 to the end.

        // String replacement.
        var s4 = "HELLO";
        Console.WriteLine(s4.Replace("LL", "XX")); // Search "LL" and replace it with "XX".

        // String split. (into a list)
        var s5 = "HELLO";
        var s5Split = s5.Split(", "); // Split a string for each ',' met.
        foreach (var s in s5Split) Console.WriteLine(s);

        // Case-shifting.
        var s6 = "HELLO";
        Console.WriteLine(s6.ToLower()); // ToUpper() vice versa.

        // Trimming.
        var s15 = "  Java and JavaScript  ";
        Console.WriteLine(s15.ToUpper()); // return "  JAVA AND JAVASCRIPT  " (without quotes)
        Console.WriteLine(s15.ToLower()); // return "  java and javascript  " (without quotes)
        Console.WriteLine(s15.Trim()); // return "Java and JavaScript" (without quotes)
        Console.WriteLine(s15.Replace("and", "or")); // return "  Java or JavaScript  " (without quotes)

        // Length of string
        var s7 = "Hello, world.";
        var s7Length = s7.Length;
        Console.WriteLine(s7Length);

        var s8 = ""; // Empty string
        Console.WriteLine(s8.Length); // return 0.

        // Null, Empty, White check for string
        string s9 = null;
        var s10 = "";
        var s11 = " ";
        var s12 = "hello";
        var s13 = " \t\n ";

        // IsNullOrEmpty()
        Console.WriteLine(string.IsNullOrEmpty(s9));
        Console.WriteLine(string.IsNullOrEmpty(s10)); // No character exist; return true.
        Console.WriteLine(string.IsNullOrEmpty(s11)); // Whitespace is character; return false.
        Console.WriteLine(string.IsNullOrEmpty(s12));

        // IsNullOrWhitespace()
        Console.WriteLine(string.IsNullOrWhiteSpace(s9));
        Console.WriteLine(string.IsNullOrWhiteSpace(s10));
        Console.WriteLine(string.IsNullOrWhiteSpace(s11));
        Console.WriteLine(string.IsNullOrWhiteSpace(s12));
        Console.WriteLine(string.IsNullOrWhiteSpace(s13)); // return true.

        // String searching
        var s14 = "Java and javaScript"; // WUT..?
        Console.WriteLine(s14.Contains("Java")); // return true.
        Console.WriteLine(s14.EndsWith("Java")); // return false.
        Console.WriteLine(s14.IndexOf("Java")); // Can find "Java" at index 0; return 0.
        Console.WriteLine(s14.LastIndexOf("Java")); // The Last "Java" found is at index 9; return 9.


        // StringBuilder is MUTABLE
        // You should check the way StringBuilder in the site or docs.
        // There are many overriding methods for this.
        // Check this out >>> https://learn.microsoft.com/ko-kr/dotnet/standard/base-types/stringbuilder
        // Examples below are ones of the usages:
        var sb1 = new StringBuilder();

        // Append(string)
        sb1.Append("C#, ");
        Console.WriteLine(sb1); // Return "C#, ". (without quotes)
        sb1.Length = 0; // Clearing the StringBuilder.

        // AppendFormat(Formatted string with variable slots, slot1, slot2, ...)
        var num1 = 1;
        var num2 = 2.2f;
        var sNum3 = "ABC";
        sb1.AppendFormat("Three variables are put : {0}, {1}, {2}", num1, num2, sNum3);
        Console.WriteLine(sb1); // Return "Three variables are put : 1, 2.2, ABC". (without quotes)

        // Insert(startIndex, string to insert, [how many times?])
        var initialValue = "--[]--";
        var sb2 = new StringBuilder(initialValue);
        var xyz = "xyz";
        sb2.Insert(3, xyz, 3);
        Console.WriteLine(sb2); // Return "--[xyzxyzxyz]--". (without quotes)

        // Remove(startIndex, length)
        var sb3 = new StringBuilder("You have selected Microsoft Sam as the default computer voice.");
        sb3.Remove(4, 5); // "have " erased.
        Console.WriteLine(sb3); // Return "You selected Microsoft Sam as the default computer voice.". (w/o quotes)

        // Replace(old-characters, new-characters)
        var sb4 = new StringBuilder("The quick brown fox jumped over the lazy dog.");
        sb4.Replace("quick", "slow");
        sb4.Replace("lazy", "woke-up");
        Console.WriteLine(sb4); // Return "The slow brown fox jumped over the woke-up dog.". (without quotes)

        // Method chaining
        // Recursively call methods returning the reference of themselves.
        // Example below is method chaining by calling multiple Append().
        var sb5 = new StringBuilder();
        sb5.Append("No, ").Append("No. ").Append("I said \"No.\"");
        Console.WriteLine(sb5); // Return "No, No. I said "No."". (w/o the outside quotes)

        // Reference equality check among strings.
        var str1 = "Hello";
        var str2 = "Hello";
        var str3 = new string(new[] { 'h', 'e', 'l', 'l', 'o' });
        var str4 = "Hel" + "lo";
        var str5 = "Hel" + GetLo();

        Console.WriteLine(ReferenceEquals(str1, str2)); // Return true.
        Console.WriteLine(ReferenceEquals(str1, str3)); // Return false.
        Console.WriteLine(ReferenceEquals(str1, str4)); // Return true.
        Console.WriteLine(ReferenceEquals(str1, str5)); // Return false.

        // Accessor(getter)
        var river = "river";
        var uppercased = river.ToUpper(); // ToUpper() is Accessor; Will NOT modify the original.
        Console.WriteLine($"{river}, {uppercased}"); // "river, RIVER"

        // Mutator(setter)
        var box = new Rectangle(5, 10, 60, 40);
        box.Inflate(25, 30); // Inflate() is Mutator; Original value will be changed.
        Console.WriteLine($"{box.X}, {box.Y}, {box.Width}, {box.Height}");

        // Code performance test by using Stopwatch class.
        // You should make instance and Start() at the start of the codes to see the elapsed time, actually.
        var stopwatch = new Stopwatch();
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
        Console.WriteLine(stopwatch.ElapsedMilliseconds); // ElapsedMilliseconds property to show time elapsed in ms.
    }

    public static string GetLo()
    {
        return "lo";
    }
}