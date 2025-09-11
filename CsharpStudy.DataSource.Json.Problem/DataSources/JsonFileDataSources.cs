using CsharpStudy.DataSource.Json.Problem.Interfaces;
using CsharpStudy.DataSource.Json.Problem.Models;
using Newtonsoft.Json;

namespace CsharpStudy.DataSource.Json.Problem.DataSources;

public class JsonFileDataSources : IDateSource // JSON 파일 기반 데이터 소스 구현체 
{
    private string _filePath;


    public JsonFileDataSources(string filePath)
    {
        _filePath = filePath;
    }


    // 계약서 의무조항을 실제로 구현 = How 어떻게 
    public async Task<List<Person>> GetPeopleAsync()
    {
        // 읽는 코드 
        // 1. 파일을 비동기적으로 읽어 전체 텍스트를 문자열로 가져오기 
        try
        {
            string jsonText = await File.ReadAllTextAsync(_filePath);
            //2. Json 문자열을 List<Person> 객체로 변환(역직렬화)
            //Person[]? people = JsonConvert.DeserializeObject<Person[]>(jsonText);
            var people = JsonConvert.DeserializeObject<List<Person>>(jsonText);


            //return _dateSourceImplementation.GetPeopleAsync();
            //return Task.FromResult(); // 뭔갈 리턴해야함 
            return people ?? []; // try- catch 나중에  > 널인경우 > [] : new List 생성 
            // people != null ? people : [] >> 삼항연산
            // people ?? [] : 앞에 것이 null 이면 뒤의 것을 가지겠다 > default value 가진다.  
        }
        catch (Exception ex)
        {
            //return new List<Person>();
            return [];
        }
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        // 저장하는 코드 
        await JsonSerialization(people);
    }

    private async Task JsonSerialization(List<Person> people)
    {
        //Person person = new Person();
        // 직렬화 : 객체를 Json 문자열로 변환
        string jsonString = JsonConvert.SerializeObject(people);
        // 3. 변환된 결과 확인
        //Console.WriteLine(people);
        //Console.WriteLine(jsonString);
        // 4. 변환된 json 문자열을 "people.json"파일에 저장
        //File.WriteAllText(FilePath, jsonString);
        await File.WriteAllTextAsync(_filePath, jsonString);
    }
}