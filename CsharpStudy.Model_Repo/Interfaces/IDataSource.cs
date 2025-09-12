using Model_Repo.Models;

namespace Model_Repo.Interfaces;

public interface IDataSource<T>
{
    Task<List<T>> LoadAllAsync();
    Task SaveAllAsync(List<T> list);
}