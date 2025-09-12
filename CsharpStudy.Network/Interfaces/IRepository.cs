using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Interfaces;

public interface IRepository<T>
{
    Task<Pokemon?> GetByNameAsync(string name);
}