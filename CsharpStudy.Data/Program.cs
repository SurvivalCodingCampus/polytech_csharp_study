using Newtonsoft.Json;
using System.IO;
namespace CsharpStudy.Data;

public class Program
{
    private const string DEFAULT_PATH = "../../data.json";
    
    static void Main(string[] args)
    {
        var department = InitDepartment();
        Serialrize(department);
        var obj = DeserialrizeOrNull<Department>();
        Console.WriteLine(obj);
    }
    
    public static Department InitDepartment()
    {
        return new Department("총무부", new Employee("홍길동", 41));
    }
    
    public static void Serialrize(object obj, string filePath = DEFAULT_PATH)
    
    {
        var toJson = JsonConvert.SerializeObject(obj);
        File.WriteAllText(filePath, toJson);
    }
    public static T? DeserialrizeOrNull<T>(string filePath = DEFAULT_PATH)
    {
        if (string.IsNullOrWhiteSpace(filePath)) 
            throw new ArgumentNullException(nameof(filePath));
        if (File.Exists(filePath) == false)
            throw new FileNotFoundException(filePath);
        
        string text = File.ReadAllText(filePath);
        
        return JsonConvert.DeserializeObject<T>(text);
    }
    

}