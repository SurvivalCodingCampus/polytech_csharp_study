using System.Globalization;
using CsharpStudy.DataSource.Repository.Data.DataSources;
using CsharpStudy.DataSource.Repository.Models;

namespace CsharpStudy.DataSource.Repository.Data.Repositories;

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


    public async Task<List<Item>> GetItemsAsync() // 모든 아이템 목록을 비동기적으로 가져오는 메서드 
    {
        var items = await _itemDataSource.LoadAllItemsAsync();
        return items;
    }

    public async Task<Item?> GetItemByIdAsync(int itemId) // 특정 아이템을 비동기적으로 검색하는 메서드 
    {
        var items = await GetItemsAsync();
        Item? item = items.FirstOrDefault(item => item.Id == itemId);
        return item;
    }

    public async Task<bool> AddItemAsync(Item newItem) // 아이템을 인벤토리에 추가하는 메서드, 성공시 true. 실패시 false 

    {
        List<Item> itemAllinInventory = await _itemDataSource.LoadAllItemsAsync();
        int countSlot = itemAllinInventory.Count; //  int countSlot = (await GetItemsAsync()).Count;
        if (countSlot >= _maxSlot)
        {
            return false;
        }

        Item? findItem = await GetItemByIdAsync(newItem.Id);
        if (findItem == null)
        {
            itemAllinInventory.Add(newItem);
            return true;
        }
        else // 이미 있음, 몇 개 있는지 모름 > 더했는데 초과시 f, 더했는데 초과x t
        {
            if (newItem.Count >= _maxStack)
            {
                return false;
            }

            if (newItem.Count + findItem.Count >= _maxStack)
            {
                return false;
            }

            findItem.Count += newItem.Count;
            return true;
        }
    }
}