namespace CshapStudy.Repository;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item?> GetItemByldAsync(int itemld);
    Task<bool> AddItemAsync(Item item);
}