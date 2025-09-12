using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.DataSources;

public interface IDataSource<T>
{
    Task<Response<T>> GetAllAsync();
    Task<Response<T>> GetByIdAsync(int id);
    Task<Response<T>> CreatePostAsync(T post);
    Task<Response<T>> UpdatePostAsync(T post);
    Task<Response<T>> DeletePostAsync(int id);
}