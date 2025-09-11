using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.DataSources;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemsAsync();
    Task SaveAllItemsAsync(List<Item> items);
}