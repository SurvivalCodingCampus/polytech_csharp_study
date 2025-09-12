using Model_Repo.Interfaces;
using Model_Repo.Models;
using Newtonsoft.Json;

namespace Model_Repo.Datasource;

public class JsonFileItemDataSource : IDataSource<Item>
{
    private readonly string _filePath;

    public JsonFileItemDataSource(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        if (!File.Exists(filePath))
            File.Create(filePath).Close();
        _filePath = filePath;
    }

    public async Task<List<Item>> LoadAllAsync()
    {
        var readAllText = await File.ReadAllTextAsync(_filePath);
        return JsonConvert.DeserializeObject<List<Item>>(readAllText) ?? [];
    }

    public async Task SaveAllAsync(List<Item> list)
    {
        var serializeObject = JsonConvert.SerializeObject(list);
        await File.WriteAllTextAsync(_filePath, serializeObject);
    }
}