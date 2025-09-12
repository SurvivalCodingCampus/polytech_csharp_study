using _250911.Data.DataSources;
using _250911.Models;

namespace _250911.Data.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private IItemDataSource _itemDataSource;
    private int _maxSlot;
    private int _maxStack;
    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStack)
    {
        _itemDataSource = itemDataSource;
        _maxSlot = maxSlot;
        _maxStack = maxStack;
    }

    //모든 아이템 목록을 비동기적으로 가져오는 메서드.
    public async Task<List<Item>> GetItemsAsync()
    {
        return await _itemDataSource.LoadAllItemsAsync();
    }

    //특정 아이템을 비동기적으로 검색하는 메서드.
    public async Task<Item?> GetItemByIdAsync(int itemId)
    {
        List<Item> items = await GetItemsAsync();
        Item? item = items.FirstOrDefault(i=>i.Id==itemId);
        return item;
    }

    //아이템을 인벤토리에 추가하는 메서드. 성공시 true, 실패시 false
    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> items = await GetItemsAsync();

        if (items.Count >= _maxSlot)
        {
            return false;
        }
        
        Item? itemReal = items.FirstOrDefault(i=>i.Name==item.Name);

        if (itemReal != null)
        {
            itemReal.Count++;
            if (itemReal.Count > _maxStack)
            {
                return false;
            }
        }
        
        else
        {
            items.Add(item);
        }
        await _itemDataSource.SaveAllItemsAsync(items);
        return true;
    }

}