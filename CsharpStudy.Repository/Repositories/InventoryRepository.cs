using CsharpStudy.Repository.DataSources;
using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private IItemDataSource _dataSource;
    private int _maxSlot;
    private int _maxStack;

    public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
    {
        _dataSource = dataSource;
        _maxSlot = maxSlot;
        _maxStack = maxStack;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await _dataSource.LoadAllItemsAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int itemId)
    {
        List<Item> allItems = await _dataSource.LoadAllItemsAsync();
        return allItems.FirstOrDefault(i => i.Id == itemId);
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> allItems = await _dataSource.LoadAllItemsAsync();
        bool hasItem = allItems.Any(e => e.Id == item.Id);

        if (hasItem)
        {
            // 인벤토리에 있으면 Count 증가
            Item findItem = allItems.First(e => e.Id == item.Id);
            
            // maxStack 꽉 찼음
            if (findItem.Count >= _maxStack)
            {
                return false;
            }
            
            findItem.Count += item.Count;

            // 단 maxStack을 초과할 수 없음
            if (findItem.Count > _maxStack)
            {
                findItem.Count = _maxStack;
            }

            return true;
        }
        else
        {
            // 인벤토리에 없으면 인벤토리에 추가
            // 단, maxSlot 수를 초과할 수 없음

            if (allItems.Count >= _maxSlot)
            {
                return false;
            }

            allItems.Add(item);
        }

        await _dataSource.SaveAllItemsAsync(allItems);
        return true;
    }
}