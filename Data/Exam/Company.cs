using Newtonsoft.Json;
using System.IO;
using System;

namespace Data;

/*총무부 리더 홍길동(41세) 인스턴스를 직렬화하여 company.json 파일에 Json String 형태로 저장하는
프로그램을 작성하시오*/

public class Company
{
    static void Main(string[] args)
    {
        Employee employees = new Employee("홍길동", 41);
        Department department = new Department("총무부", employee);

        string jsonString = JsonConvert.SerializeObject(department, Formatting.Indented);
        File.WriteAllText("company.json", jsonString);
    }
    
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
}