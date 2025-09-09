using System.Text.Json;

namespace Csharp.Study.DataSource;

public class JsonFileDataSource : IDataSource //json 파일을 이용해 IDataSource 약속을 실제로 구현한 클래스
{
    private string _filePath; //인스턴스가 사용할 파일 경로

    public JsonFileDataSource(string filePath) //생성자
    {
        _filePath = filePath;
    }

    public async Task<List<Person>> GetPeopleAsync() //파일->문자열->List<Person>로 역직렬화
    {
        
        string json = await File.ReadAllTextAsync(_filePath); //파일 내용을 비동기로 읽기
        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(json);
        
        return people;
    }
    
    public async Task SavePeopleAsync(List<Person> people)
    {
        string json = JsonSerializer.Serialize(people);
        await File.WriteAllTextAsync(_filePath, json);
    }
}