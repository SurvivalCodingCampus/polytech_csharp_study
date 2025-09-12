namespace CsharpStudy.Network.Interfaces;

public interface IDataSource<T>
{
    Task<Response<T>> GetNameAsync(string name);
}