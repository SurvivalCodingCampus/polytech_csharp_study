using Newtonsoft.Json;

namespace CaharpStudy._2hakgi.EX;


public class Department
{
    public string Name { get; }
    public Emplovee leader { get; }

    public Department(string name, Emplovee leader)
    {
        Name = name;
        this.leader = leader;
    }

    public static void Main(string[] args)
    {
        //직렬화
        Department department = new Department("총무부", new Emplovee("홍길동", 41));
        string company = JsonConvert.SerializeObject(department);
        Console.WriteLine(department);
        Console.WriteLine(company);
        System.IO.File.WriteAllText("company.json", company);
        
    }

    public void JsonDeserialization()
    {
        //역직렬화
        Department department = new Department("총무부", new Emplovee("홍길동", 41));
        string jsonString = JsonConvert.SerializeObject(department);
    }
}