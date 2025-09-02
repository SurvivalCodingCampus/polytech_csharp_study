using Newtonsoft.Json;

namespace CsharpStudy.DataFormat;

public class Emplovee
{
    public string Name { get; }
    public int Age { get; }

    public Emplovee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Department
{
    public string Name { get; }
    public Emplovee leader { get; }

    public Department(string name, Emplovee leader)
    {
        Name = name;
        this.leader = leader;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Emplovee emplovee = new Emplovee("홍길동", 41);
        Department department = new Department("총무부", emplovee);
        
        // 직렬화
        string JsonString = JsonConvert.SerializeObject(department);
        File.WriteAllText("company.json", JsonString);
        Console.WriteLine(JsonString);
        
        // 역직렬화
        string Company = File.ReadAllText("company.json");
        Department? loadedCompany = JsonConvert.DeserializeObject<Department>(Company);
        Console.WriteLine(loadedCompany);
    }
}