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

class Department
{
    public string Name { get; }
    public Employee leader { get; }

    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }
}

public class User
{
    public static void Main()
    {
        Employee user1 = new Employee("홍길동", 41);
        Department user2 = new Department("홍길동", user1);

        string jsonString = JsonConvert.SerializeObject(user1);
        string jsonString2 = JsonConvert.SerializeObject(user2);
        
        File.WriteAllText("company.json", jsonString);
        File.AppendAllText("company.json", jsonString2);
    }
}