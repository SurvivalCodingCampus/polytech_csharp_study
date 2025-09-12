namespace CsharpStudy.Http.DataSources;

public interface IDataSource<T>
{
    Task<Response<List<T>>> GetAllAsync();
    Task<Response<T>> GetByIdAsync(int id);
    Task<Response<T>> CreateAsync(T item);
    Task<Response<T>> UpdateAsync(T item);
    Task<Response<bool>> DeleteAsync(int id);
}