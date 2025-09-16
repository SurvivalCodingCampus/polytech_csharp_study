using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Interfaces;

public interface IRepository<T>
{
    Task<T> GetByNameAsync(string name);
}