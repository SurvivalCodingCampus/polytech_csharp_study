using CsharpStudy.DataSource.DataSources;
using CsharpStudy.DataSource.Interfaces;
using CsharpStudy.DataSource.Models;

namespace CsharpStudy.DataSource;

class Program
{
    static async Task Main(string[] args)
    {
        // IDataSource dataSource = new JsonFileDataSource("people.json");
        IDataSource dataSource = new MockDataSource();

        // 비지니스 로직
        // 읽기
        List<Person> people = await dataSource.GetPeopleAsync();
        List<Person> adults = people.Where(p => p.Age >= 19).ToList();
        adults.ForEach(p => Console.WriteLine($"{p.Name} ({p.Age})"));

        // 추가
        people.Add(new Person("홍길동", 10));
        await dataSource.SavePeopleAsync(people);
        Console.WriteLine("추가 후 저장 완료");

        // 삭제
        await dataSource.SavePeopleAsync(people.Where(p => p.Name != "이민준").ToList());


        Person person = new Person("aa", 10);

        // Person person2 = new Person();
        // person2.Name = "aaa";
        // person2.Age = 100;
        // 
        // Person person2 = new Person
        // {
        //     Name = "aaa",
        //     Age = 100
        // };

        Console.WriteLine("Hello, World!");
    }
}