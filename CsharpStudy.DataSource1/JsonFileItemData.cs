using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CsharpStudy.DataSource1;

public class JsonFileItemData : IItemDataSource
{
    private string _filePath;

    public JsonFileItemData(string filePath)
    {
        this._filePath = filePath;
    }

    public async Task<List<Item>> LoadAllItemsAsync()
    {
        try
        {
            string jsonString = await File.ReadAllTextAsync(this._filePath);
            return JsonConvert.DeserializeObject<List<Item>>(jsonString) ?? [];
        }
        catch(FileNotFoundException e)
        {
            return [];
        }
    }

    public async Task SaveAllItemAsync(List<Item> items)
    {
        string jsonString = JsonConvert.SerializeObject(items);
        await File.WriteAllTextAsync(this._filePath, jsonString);
    }
}