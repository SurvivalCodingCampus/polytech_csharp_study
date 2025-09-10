using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CshapStudy.DataSource;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public interface IDataSource
{
    Task<List<Person>> GetPeolpeAsync();
    Task SavePeopleAsync(List<Person> people);
}

public class JsonFileDataSource : IDataSource
{
    private string _filePath;

    public JsonFileDataSource(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<List<Person>> GetPeolpeAsync()
    {
        /*string jsonString = await File.ReadAllTextAsync(_filePath);
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonString) ?? [];

        return people;
        
        */
        if (!File.Exists(_filePath))
        {
            await File.WriteAllTextAsync(_filePath, "[]");
        }


        string jsonString = await File.ReadAllTextAsync(_filePath);
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonString) ?? new List<Person>();

        return people;
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        
        try
        {
            string jsonString = JsonConvert.SerializeObject(people, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, jsonString);
            Console.WriteLine($"파일이 성공적으로 생성되었습니다: {_filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일 생성 중 오류가 발생했습니다: {ex.Message}");
        }
    }
}