using CshapStudy.DataSource0911.Models;

namespace CshapStudy.DataSource0911.Data;


public interface IInventoryRepository
{
    Task<List<Item>>GetItemsAsync();
    Task<Item?> GetItemAsync(int itemId);
    Task<bool> AddItemAsync(Item item);
}

