namespace CsharpStudy._2hakgi.Assignment.DataSource;

public interface IDataSource
{ 
    abstract Task<List<Person>> GetPeopleAsync();

    abstract Task SavePeopleAsync(List<Person> people);

}