using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.Repository;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item?> GetItemByIdAsync(int itemId);
    Task<bool> AddItemAsync(Item item);

}