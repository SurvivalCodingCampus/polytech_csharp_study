namespace CshapStudy.Repository;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item?> GetItemByIdAsync(int itemld);
    Task<bool> AddItemAsync(Item item);
}