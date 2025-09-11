using CsharpStudy.Repository.Data.DataSources;
using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.Repository;

public class InventoryRepository : IInventoryRepository
{
    IItemDataSource ItemDataSource { get; set; }
    private int MaxSlot { get; set; }
    private int MaxStack { get; set; }

    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStack)
    {
        ItemDataSource = itemDataSource;
        this.MaxSlot = maxSlot;
        this.MaxStack = maxStack;
    }

    public Task<List<Item>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Item?> GetItemByIdAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddItemAsync(Item item)
    {
        throw new NotImplementedException();
    }
}