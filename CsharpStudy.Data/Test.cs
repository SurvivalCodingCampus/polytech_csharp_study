using Newtonsoft.Json;
namespace CsharpStudy.Data;

public class Employee
{
    public string Name { get; }
    public int Age { get; }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Department
{
    public string Name { get; }
    public Employee leader { get; }

    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }
}

public class Test
{
    static void Main(string[] args)
    {
        JsonDeserialization();
    }
    
    static void JsonSerialization()
    {
        // 직렬화
        Employee employee = new Employee("홍길동", 41);
        
        string jsonString = JsonConvert.SerializeObject(employee);
        Console.WriteLine(employee);
        Console.WriteLine(jsonString);
        File.WriteAllText("company.json", jsonString);
    }
    
    static void JsonDeserialization()
    {
        // 역직렬화
        string jsonString = File.ReadAllText("company.json");
        Employee? employee = JsonConvert.DeserializeObject<Employee>(jsonString);
        
        Console.WriteLine(employee);
    }
}