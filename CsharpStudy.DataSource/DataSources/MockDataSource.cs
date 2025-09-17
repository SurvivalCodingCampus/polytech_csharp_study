using CsharpStudy.DataSource.Interfaces;
using CsharpStudy.DataSource.Models;

namespace CsharpStudy.DataSource.DataSources;

public class MockDataSource : IDataSource
{
    private List<Person> _people = [
        new Person("John", 10),
        new Person("홍길동", 20),
        new Person("김삿갓", 10),
    ];
    
    public async Task<List<Person>> GetPeopleAsync()
    {
        return _people;
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        _people = people;
    }
}