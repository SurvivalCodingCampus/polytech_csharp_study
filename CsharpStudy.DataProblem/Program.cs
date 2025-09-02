using Newtonsoft.Json;

namespace CsharpStudy.DataProblem;

public class Employee
{
    public string Name { get; } // get : 가져와 읽기만 가능 
    public int Age { get; }

    // 생성자 
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


    // 생성자 
    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(leader)}: {leader}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        JsonSerialization(); // 직렬화 코드  
    }

    static void JsonSerialization()
    {
        // 직렬화 
        // 1. 메모리에 객체 생성후 데이터 채우기 
        Employee leaderEmployee = new Employee("홍길동", 41);
        Department department = new Department("총무부", leaderEmployee);
        // 직렬화 
        string jsonString00 = JsonConvert.SerializeObject(department);
        // 3. 변환 결과 확인 
        Console.WriteLine(department);
        Console.WriteLine(jsonString00);
        // 4. 변환된 json 문자열을 해당 파일에 저장
        File.WriteAllText("company.json", jsonString00);
    }
}