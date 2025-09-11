using CsharpStudy.DataSource.Models;

namespace CsharpStudy.DataSource.Interfaces;

public interface IDataSource
{
    public Task<List<Person>> GetPeopleAsync();
    public Task SavePeopleAsync(List<Person> people);
}