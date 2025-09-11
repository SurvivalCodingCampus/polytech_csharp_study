namespace CsharpStudy.DataSource1;

public class InventoryRepository : IInventoryRepository
{
    private IItemDataSource _itemDataSource;
    private int MaxSlot { get; set; }
    private int MaxStack { get; set; }

    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStack)
    {
        _itemDataSource = itemDataSource;
        MaxSlot = maxSlot;
        MaxStack = maxStack;
    }
    
    public async Task<List<Item>> GetItemsAsync()
    {
        return await _itemDataSource.LoadAllItemsAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int itemId)
    {
        List<Item> itemList = await GetItemsAsync();
        return itemList.FirstOrDefault(x => x.id == itemId);
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> itemList = await GetItemsAsync();
        Item? addItem = await GetItemByIdAsync(item.id);

        if (addItem == null)
        {
            if (itemList.Count >= MaxSlot)
            {
                return false;
            }
            itemList.Add(item);
            await _itemDataSource.SaveAllItemAsync(itemList);
            return true;
        }

        if (addItem.count + item.count > MaxStack)
        {
            return false;
        }
        
        addItem.count += item.count;
        await _itemDataSource.SaveAllItemAsync(itemList);
        return true;
    }
}