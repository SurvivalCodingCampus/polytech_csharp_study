using CsharpStudy.DataSource.DataSources;
using CsharpStudy.DataSource.Interfaces;
using CsharpStudy.DataSource.Models;

namespace CsharpStudy.DataSource;

class Program
{
    
    static async Task Main(string[] args)
    {
        IDataSource dataSource = new JsonFileDataSource("people.json");
        
        // 1. 데이터를 불러와 필터링하는 로직
        var people = await dataSource.GetPeopleAsync();
        var adults = people.Where(person => person.Age >= 19).ToList();
        Console.WriteLine("성인만 출력:");
        adults.ForEach(person => Console.WriteLine($"- {person.Name}, {person.Age}세"));
        
        // 2. 데이터를 추가하고 저장하는 로직
        people.Add(new Person("김민지", 15));
        await dataSource.SavePeopleAsync(people);
        Console.WriteLine("김민지 추가 후 저장 완료");
        
        // 3. 데이터를 삭제하는 로직
        var toDelete = people.FirstOrDefault(person => person.Name == "이민준");

        if (toDelete != null)
        {
            people.Remove(toDelete);
            await dataSource.SavePeopleAsync(people);
            Console.WriteLine("이민준 삭제 후 저장 완료");
        }

        dataSource.PrintPeople(people);
    }
    
}