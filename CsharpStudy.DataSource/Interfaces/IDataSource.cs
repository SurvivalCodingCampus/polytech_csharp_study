using CsharpStudy.DataSource.Models;

namespace CsharpStudy.DataSource.Interfaces;

public interface IDataSource
{
    Task<List<Person>> GetPeopleAsync();
    Task SavePeopleAsync(List<Person> people);
    public void PrintPeople(List<Person> people);
}