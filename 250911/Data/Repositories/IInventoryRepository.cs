using _250911.Models;

namespace _250911.Data.Repositories;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item?>GetItemByIdAsync(int itemId);
    Task<bool> AddItemAsync(Item item);
}