using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CsharpStudy.Data;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Employee() { }
}

public class Department
{
    public string Name { get; set; }
    public Employee leader { get; set; }

    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }
    
    public Department() { }
}

class program
{
    static void Main(string[] args)
    {
        Employee leader = new Employee("홍길동", 41);

        Department dp = new Department("총무부", leader);
        
        string json = JsonConvert.SerializeObject(dp, Formatting.Indented);
        
        File.WriteAllText("company.json", json);

        Console.WriteLine(json);
    }
}