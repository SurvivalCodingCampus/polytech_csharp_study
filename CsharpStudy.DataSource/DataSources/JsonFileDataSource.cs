using CsharpStudy.DataSource.Interfaces;
using CsharpStudy.DataSource.Models;
using Newtonsoft.Json;

namespace CsharpStudy.DataSource.DataSources;

public class JsonFileDataSource : IDataSource
{
    private string _filePath;

    public JsonFileDataSource(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        try
        {
            string jsonString = await File.ReadAllTextAsync(_filePath);
            // List<Person>? people = JsonConvert.DeserializeObject<List<Person>>(jsonString);
            // List<Person> result = [];
            // if (people == null)
            // {
            //     result = new List<Person>();
            // }
            // return result;
            return JsonConvert.DeserializeObject<List<Person>>(jsonString) ?? [];
        }
        catch (FileNotFoundException e)
        {
            return [];
        }
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        string jsonString = JsonConvert.SerializeObject(people);
        await File.WriteAllTextAsync(_filePath, jsonString);
    }
}