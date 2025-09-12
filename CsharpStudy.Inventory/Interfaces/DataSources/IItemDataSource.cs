using CsharpStudy.Inventory.Models;

namespace CsharpStudy.Inventory.Interfaces.DataSources;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemsAsync();
    Task SaveAllItemsAsync(List<Item> items);
}