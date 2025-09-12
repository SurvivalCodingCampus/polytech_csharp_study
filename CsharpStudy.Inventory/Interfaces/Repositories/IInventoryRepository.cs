using CsharpStudy.Inventory.Models;

namespace CsharpStudy.Inventory.Interfaces.Repositories;

public interface IInventoryRepository
{
    Task<List<Item>> GetAllItemsAsync();
    Task<Item?> GetItemByIdAsync(int itemId);
    Task<bool> AddItemAsync(Item item);
}