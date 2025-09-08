using CsharpStudy.MyData.Example;
using Newtonsoft.Json;

namespace CsharpStudy.MyData;

class Program
{
    static void Main(string[] args)
    {
        // JsonSerializeExample();
        // JsonDeserializeExample();
        
        JsonSerialize(new Department("총무부", new Employee("홍길동", 41))); 
    }

    static void JsonSerialize(object o)
    {
        string json = JsonConvert.SerializeObject(o);
        Console.WriteLine(json);
        
        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "company.json"), json);
    }

    static void JsonSerializeExample()
    {
        User user = new User("Jane", "abc@no-reply-example.com");
        string jsonString = JsonConvert.SerializeObject(user);
        
        Console.WriteLine(jsonString);
        // Console.WriteLine($"File Location is ::: {Path.Combine(Directory.GetCurrentDirectory(), "test.json")}");
        // Output : File Location is ::: C:\_Workplace\polytech_csharp_study\CsharpStudy.MyData\bin\Debug\net8.0\test.json

        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "test.json"), jsonString);
    }

    static void JsonDeserializeExample()
    {
        string jsonString = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "test.json"));
        User? user = JsonConvert.DeserializeObject<User>(jsonString);
        Console.WriteLine(user?.ToString());
    }
}