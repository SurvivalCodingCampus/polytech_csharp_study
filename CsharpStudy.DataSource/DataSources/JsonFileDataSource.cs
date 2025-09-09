using CsharpStudy.DataSource.Interfaces;
using CsharpStudy.DataSource.Models;
using Newtonsoft.Json;

namespace CsharpStudy.DataSource.DataSources;

public class JsonFileDataSource :  IDataSource
{
    string _fileName;
    // Constructor
    public JsonFileDataSource(string fileName)
    {
        _fileName = fileName;
    }
    
    // Methods
    // : Deserialization
    public async Task<List<Person>> GetPeopleAsync()
    {
        List<Person>? people;
        string fromJson;
        
        try
        {
            fromJson = File.ReadAllText("people.json");
        }
        catch (FileNotFoundException e)
        {
            fromJson = string.Empty;
            File.Create("people.json").Close();
            Console.WriteLine("people.json not found; people.json is newly created.");
        }
        
        people = JsonConvert.DeserializeObject<List<Person>>(fromJson) ?? new();
        return await Task.FromResult(people);
    }

    // : Serialization
    public async Task SavePeopleAsync(List<Person> people)
    {
        var toJson = JsonConvert.SerializeObject(people);
        await Task.Run(() => File.WriteAllText("people.json", toJson));
    }

    public void PrintPeople(List<Person> people)
    {
        Console.WriteLine($"사용자 총원 = {people.Count}");
        foreach (var person in people)
        {
            Console.WriteLine($"{person}");
        }
    }
}