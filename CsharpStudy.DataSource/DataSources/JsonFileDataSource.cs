using Newtonsoft.Json;

namespace CsharpStudy.DataSource;

public class JsonFileDataSource : IDataSource
{
    private readonly string _filePath;

    public JsonFileDataSource(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        if (!File.Exists(filePath))
            File.Create(filePath).Close();
        _filePath = filePath;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        var readAllText = await File.ReadAllTextAsync(_filePath);
        return JsonConvert.DeserializeObject<List<Person>>(readAllText) ?? [];
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        var serializeObject = JsonConvert.SerializeObject(people);
        await File.WriteAllTextAsync(_filePath, serializeObject);
    }
}