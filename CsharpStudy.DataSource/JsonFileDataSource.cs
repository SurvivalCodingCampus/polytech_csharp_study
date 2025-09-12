using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// 1. 데이터 모델
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// 2. 데이터 소스 계약 정의
public interface IDataSource
{
    Task<List<Person>> GetPeopleAsync();           
    Task SavePeopleAsync(List<Person> people);       
}

// 3. JSON 파일 기반 데이터 소스 구현체
public class JsonFileDataSource : IDataSource
{
    private readonly string filePath;

    public JsonFileDataSource(string path)
    {
        filePath = path;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        if (!File.Exists(filePath))
            return new List<Person>();

        using FileStream stream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<List<Person>>(stream)
               ?? new List<Person>();
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        using FileStream stream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(stream, people,
            new JsonSerializerOptions { WriteIndented = true });
    }
}

// 애플리케이션 진입점
class Program
{
    static async Task Main(string[] args)
    {
        IDataSource dataSource = new JsonFileDataSource("people.json");

        // 1. 데이터를 불러와 필터링하는 로직
        var people = await dataSource.GetPeopleAsync();
        var adults = people.Where(p => p.Age >= 19).ToList();
        Console.WriteLine("성인만 출력:");
        adults.ForEach(p => Console.WriteLine($"- {p.Name} ({p.Age}세)"));

        // 2. 데이터를 추가하고 저장하는 로직
        people.Add(new Person { Name = "김민지", Age = 15 });
        await dataSource.SavePeopleAsync(people);
        Console.WriteLine("\n김민지 추가 후 저장 완료.");

        // 3. 데이터를 삭제하는 로직
        var toDelete = people.FirstOrDefault(p => p.Name == "이민준");
        if (toDelete != null)
        {
            people.Remove(toDelete);
            await dataSource.SavePeopleAsync(people);
            Console.WriteLine("\n이민준 삭제 후 저장 완료.");
        }
    }
}
