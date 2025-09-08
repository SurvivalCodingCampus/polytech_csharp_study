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
    // Main Thread
    static void Main(string[] args)
    {
        JsonSerialization();
    }

    static void JsonSerialization()
    {
        // 직렬화
        Department department = new Department("총무부", new Employee("홍길동", 41));

        string jsonString = JsonConvert.SerializeObject(department);
        Console.WriteLine(department);
        Console.WriteLine(jsonString);
        
        // 다른 스레드 생성
        File.WriteAllTextAsync("company.json", jsonString)
            .ContinueWith(task =>
            {
                File.WriteAllTextAsync("hero.txt", "영웅정보");
                Console.WriteLine("저장완료 : 2");
            });
         
         // Main Thread
        Console.WriteLine("저장완료 : 1");  // 얘가 더 먼저 진행
    }

    static void JsonDeserialization()
    {
        // 역직렬화
        string jsonString = File.ReadAllText("company.json");
        Employee? employee = JsonConvert.DeserializeObject<Employee>(jsonString);

        Console.WriteLine(employee);
    }
}
