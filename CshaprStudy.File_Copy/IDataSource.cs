namespace CshaprStudy.File_C;

public interface IDataSource
{
    Task<List<Person>> GetPeopleAsync();
    Task SavePeopleAsync(List<Person> people);
    
    

}