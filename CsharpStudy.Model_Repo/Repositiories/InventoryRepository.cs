using Model_Repo.Interfaces;
using Model_Repo.Models;

namespace Model_Repo.Repositiories;

public class InventoryRepository : IInventoryRepository
{
    private readonly IDataSource<Item> _dataSource;
    private readonly int _maxSlot;
    private readonly int _maxStack;

    public InventoryRepository(IDataSource<Item> dataSource, int maxSlot, int maxStack)
    {
        if (dataSource == null)
            throw new ArgumentNullException(nameof(dataSource));
        if (maxSlot <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxSlot));
        if (maxStack <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxStack));

        _dataSource = dataSource;
        _maxSlot = maxSlot;
        _maxStack = maxStack;
    }

    public Task<List<Item>> GetItemsAsync()
    {
        return _dataSource.LoadAllAsync();
    }

    public async Task<Item> GetItemByIdAsync(int itemId)
    {
        List<Item> items = await _dataSource.LoadAllAsync();
        return items.Find(it => it.Id == itemId) ?? throw new ItemNotFountException();
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> items = await _dataSource.LoadAllAsync();
        Item? itemOrNull = items.Find(it => it.Equals(item));

        if (itemOrNull == null)
        {
            if (CanAddSlot(items) == false) return false;
            items.Add(item);
            await _dataSource.SaveAllAsync(items);
            return true;
        }

        if (CanAddStack(itemOrNull, item) == false) return false;
        itemOrNull.AddCount(item);
        await _dataSource.SaveAllAsync(items);
        return true;
    }

    private bool CanAddSlot(List<Item> items) => items.Count < _maxSlot;
    private bool CanAddStack(Item originItem, Item addedItem) =>
        originItem.Count + addedItem.Count <= _maxStack;
} 

public class ItemNotFountException : Exception
{
}