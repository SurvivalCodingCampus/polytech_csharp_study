using System;
using System.IO;
using Newtonsoft.Json;

namespace CsharpStudy.Data;


class Program
{
    static void Main(string[] args)
    {
        var leader = new Employee("홍길동", 41);
        var dept = new Department("총무부", leader);

        string json = JsonConvert.SerializeObject(dept, Formatting.Indented);
        File.WriteAllText("company.json",json);
        Console.WriteLine("company.json 저장");

        string readJson = File.ReadAllText("company.json");
        Department restored = JsonConvert.DeserializeObject<Department>(readJson);
        
        Console.WriteLine($"역직렬화 확인: {restored.Name}, leader: {restored.leader.Name}({restored.leader.Age})");
    }
}