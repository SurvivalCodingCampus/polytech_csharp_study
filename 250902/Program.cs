using System.Text.Json.Serialization;
using System.Text.Json;

namespace _250902;

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee("홍길동", 41);
        string jsonString = JsonSerializer.Serialize(employee);
        System.IO.File.WriteAllText("company.json", jsonString);
        Employee? loadedEmployee = JsonSerializer.Deserialize<Employee>(jsonString);
        Console.WriteLine($"이름: {loadedEmployee.Name}, 나이: {loadedEmployee.Age}");
    }
}