using CsharpStudy.DataSource.Models;

namespace CsharpStudy.DataSource.Interfaces;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemsAsync();
    Task SaveAllItemsAsync(List<Item> items);
}