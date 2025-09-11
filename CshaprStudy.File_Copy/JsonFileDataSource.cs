using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CshaprStudy.File_C;

public class JsonFileDataSource : IDataSource
{
    public string fileName {get; set;}
    
    public List<Person> People {get; set;}
    public JsonFileDataSource(string fileName)
    {
        this.fileName = fileName;
        
        List<Person> people = new List<Person>();
        people.Add(new Person() { Name = "김지우", Age = 20 });
        people.Add(new Person() { Name = "김우우", Age = 21 });
        people.Add(new Person() { Name = "김지지", Age = 12 });
        
        string json = JsonConvert.SerializeObject(people);
        
        File.WriteAllText(fileName, json);
    }
    
    public async Task<List<Person>> GetPeopleAsync()
    {
        string json = File.ReadAllText(fileName);
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json); 
        return people;
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        string temp = JsonConvert.SerializeObject(people);
        File.WriteAllText(fileName, temp);
    }

}