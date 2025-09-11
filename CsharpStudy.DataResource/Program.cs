using System.Text.Encodings.Web;
using System.Text.Json;

namespace CsharpStudy.DataResource;

public interface IDataSource

{
    Task<List<Person>> GetPeopleAsync();
    Task SavePeopleAsync(List<Person> people);
}


public class Program

{
    static async Task Main(string[] args)
    {
        IDataSource dataSource = new JsonFileDataSource("people.json");
        
        // 1. 데이터를 불러와 필터링하는 로직
        var people = await dataSource.GetPeopleAsync();
        var adults = people.Where(p => p.Age >= 19).ToList();
        
        Console.WriteLine("성인만 출력");
        adults.ForEach(p => Console.WriteLine($"- {p.Name} ({p.Age}세)"));
        
        // 2. 데이터를 추가하고 저장하는 로직
        people.Add(new Person("김민지", 15 ));
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

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class JsonFileDataSource : IDataSource
{
    private readonly string _filePath;

    public JsonFileDataSource(string filePath)
    {
        _filePath = filePath;
    }
    
    public async Task<List<Person>> GetPeopleAsync()
    {
        // 파일이 존재하는지 확인
        if (!File.Exists(_filePath))
        {
            return new List<Person>();
        }
        
        // 파일 읽기
        var jsonString = await File.ReadAllTextAsync(_filePath);
        
        // JSON 역직렬화
        return JsonSerializer.Deserialize<List<Person>>(jsonString) ?? new List<Person>();
        
        // (파일읽기 - 역직렬화) 풀어쓴 거
        // List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonString);
        // List<Person> result = [];
        // if (people == null)
        // {
        //     result = new List<Person>();
        // }
        // return result;
        // return JsonSerializer.Deserialize<List<Person>>(jsonString) ?? [];
        
        /*---- 교수님 코드 -----*/
        // try
        // {
        //     string jsonString2 = await File.ReadAllTextAsync(_filePath);
        //
        //     // JSON 역직렬화
        //     return JsonSerializer.Deserialize<List<Person>>(jsonString) ?? new List<Person>();
        // }
        // catch (FileNotFoundException e)
        // {
        //     return [];
        // }
    }
    
    public async Task SavePeopleAsync(List<Person> people)
    {
        // json 파일 가독성 좋게 들여쓰기, 한글 유니코드 변환
        var options = new JsonSerializerOptions  
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        
        // people 리스트를 JSON 문자열로 직렬화
        var jsonString = JsonSerializer.Serialize(people, options);
        
        // 파일에 덮어쓰기
        await File.WriteAllTextAsync(_filePath, jsonString);
    }
}