using Newtonsoft.Json;

namespace CsharpStudy.JsonSerialization;

class Program
{
    public class Employee
    {
        public string Name { get; }
        public int Age { get; }

        public Employee(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public class Department
    {
        public string Name { get; }
        public Employee leader { get; }

        public Department(string name, Employee leader)
        {
            this.Name = name;
            this.leader = leader;
        }
    }

    static void Main(string[] args)
    {
        Department department = new Department(
            name: "총무부",
            leader: new Employee(
                name: "홍길동",
                age: 41
            )
        );
        
        string jsonString = JsonConvert.SerializeObject(department);
        File.WriteAllText("department.json", jsonString);
        Console.WriteLine("저장 완료");
    }
}