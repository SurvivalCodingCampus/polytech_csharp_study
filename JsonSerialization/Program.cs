using Newtonsoft.Json;

namespace JsonSerialization;

class Program
{
    public class Employee
    {
        private string Name { get; }
        private int Age { get; }

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
}

/*static void Main(string[] args)
{
    Department department = new Department(
        name: "총무부",
        leader: new Employee(name: "홍길동", age: 41));

    string jsonString=JsonConvert.SerializeObject(department);

    File.WriteAllTextAsync("department.json", jsonString).ContinueWith(Task =>
    {
        File.WriteAllTextAsync("hero.txt", "영웅 정보").ContinueWith(task =>
        {
            File.WriteAllTextAsync("hero2.txt", "영웅2 정보").ContinueWith(task => { Console.WriteLine("최종 완료"); });
        });
        Console.WriteLine("저장 완료 : 2");
    });
    Task.Delay(1000).ContinueWith(task =>
    {
        File.WriteAllTextAsync("hero3.txt", "영웅3 정보").ContinueWith(task1 => { Console.WriteLine("hero3 완료"); });
    });
    Console.WriteLine("저장 완료 : 1");

    File.WriteAllTextAsync("hero4.txt", "영웅4 정보").ContinueWith(task => { Console.WriteLine("hero4 완료"); });

    Console.ReadLine();
}
}*/