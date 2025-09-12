using Model_Repo.Models;

namespace Model_Repo.Interfaces;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item> GetItemByIdAsync(int itemId);
    Task<bool> AddItemAsync(Item item);
    
}