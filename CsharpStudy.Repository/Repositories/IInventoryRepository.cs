using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Repositories;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item?> GetItemByIdAsync(int itemId);
    Task<bool> AddItemAsync(Item item);
}