using Newtonsoft.Json;

namespace CsharpStudy.Data;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Employee()
    {
    }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
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

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(leader)}: {leader}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            JsonSerialization();
            JsonDeserialization();
        }

        static void JsonSerialization()
        {
            // 직렬화
            Employee dapartmentLeader = new Employee{Name = "홍길동 ", Age = 45};
            Department part = new Department("총무부", dapartmentLeader);
            string jsonString1 = JsonConvert.SerializeObject(part);
            Console.WriteLine(jsonString1);
            
        }

        static void JsonDeserialization()
        {
            string jsonString = "{\"Name\":\"총무부\",\"leader\":{\"Name\":\"홍길동 \",\"Age\":45}}";
            Department? department = JsonConvert.DeserializeObject<Department>(jsonString);
            Console.WriteLine(department);
        }
    }
}