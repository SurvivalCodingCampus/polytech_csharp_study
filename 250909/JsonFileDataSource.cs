using Newtonsoft.Json;

namespace _250909;

public class JsonFileDataSource : IDataSource
{
    private readonly List<Person>_people = new List<Person>();
    private string _fileName;
    
    public JsonFileDataSource(string fileName)
    {
        _fileName = fileName;
    }
    
    public async Task<List<Person>> GetPeopleAsync()
    {
        try
        {
            string jsonString = await File.ReadAllTextAsync(_fileName);
            return JsonConvert.DeserializeObject<List<Person>>(jsonString) ?? [];
        }
        
        catch(Exception e)
        {
            return [];
        }

    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        string jsonString = JsonConvert.SerializeObject(people);
        await File.WriteAllTextAsync(_fileName, jsonString);
    }
}