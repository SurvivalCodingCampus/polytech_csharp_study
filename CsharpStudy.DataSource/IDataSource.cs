namespace CsharpStudy.DataSource;

public interface IDataSource
{
    public Task<List<Person>> GetPeopleAsync();
    public Task SavePeopleAsync(List<Person> people);
    public void Add(Person person);
    public void Remove(Person person);
}