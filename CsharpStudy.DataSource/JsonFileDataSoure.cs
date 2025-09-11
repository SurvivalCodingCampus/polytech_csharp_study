namespace CsharpStudy.DataSource;
using System.Text.Json;
public class JsonFileDataSoure : IDataSource
{
    private List<Person> _people;
    private string _filePath;

    public JsonFileDataSoure(string address)
    {   
        _filePath = address;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {        
        string json = await File.ReadAllTextAsync(_filePath);
        // 읽어오기 실패시 List 객체만 생성, 초기 생성을 패스했으니 안정성을 위해 작성
        // 배열 형식의 역직렬화 -> 저장할때도 배열로 저장 필요
        _people = JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
        
        // _people 타입은 Task 타입이 아니라 직접 반환 x 
        return _people;
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        // 시도 1 : 진짜 비동기 xx
        //File.WriteAllText(_filePath, JsonSerializer.Serialize(people));
        //return Task.CompletedTask;
        var json = JsonSerializer.Serialize(people);
        await File.WriteAllTextAsync(_filePath, json); 
    }
    
    public void Add(Person person)
    {
        _people.Add(person);
    }

    public void Remove(Person person)
    {
        _people.Remove(person);
    }
}