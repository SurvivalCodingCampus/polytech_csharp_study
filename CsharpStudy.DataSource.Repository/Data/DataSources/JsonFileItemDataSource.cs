using System.Text.Json.Serialization;
using CsharpStudy.DataSource.Repository.Models;
using Newtonsoft.Json;

namespace CsharpStudy.DataSource.Repository.Data.DataSources;

public class JsonFileItemDataSource : IItemDataSource
{
    private string _filePath; // 파일 경로 작성 

    public JsonFileItemDataSource(string filePath) // 파일 경로 생성자 
    {
        _filePath = filePath;
    }

    public async Task<List<Item>> LoadAllItemsAsync() // 아이템 데이터를 읽어오는 메서드 > 데이터 읽기 > 역직렬화 
    {
        // 데이터 읽는 코드 
        //1. 파일을 비동기적으로 읽어 전체 텍스트를 문자열로 가져오김 
        try
        {
            string jsonText = await File.ReadAllTextAsync(_filePath);
            // 2. json 문자열을 List<Item> 객체로 변환(역직렬화)
            var items = JsonConvert.DeserializeObject<List<Item>>(jsonText);
            return items ?? []; // 앞의 것이 null 이면 뒤의 것을 가지겠다 
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
            //throw;
            return [];
        }
    }

    public async Task SaveAllItemAsync(List<Item> items) // 아이템 데이터를 저장하는 메서드 > 데이터 저장 > 직렬화 
    {
        // 저장하는 코드 
        await JsonSerialization(items);
    }


    private async Task JsonSerialization(List<Item> items)
    {
        // 직렬화 : 객체를 Json 문자열로 변환
        string jsonString = JsonConvert.SerializeObject(items);
        // 변환된 json 문자열을 '_filePath'파일에 저장 
        await File.WriteAllTextAsync(_filePath, jsonString);
    }
}