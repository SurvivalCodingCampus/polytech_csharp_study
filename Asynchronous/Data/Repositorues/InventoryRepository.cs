using System.Dynamic;
using Asynchronous.DataSources;

namespace Asynchronous.Data.Repositorues;

public class InventoryRepository : IInvetoryRepository
{
    private IItemDataSource _itemDataSource; //데이터를 읽고 저장
    private int _maxSlot;
    private int _maxStack;

    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStack)
    {
        _itemDataSource = itemDataSource;
        _maxSlot = maxSlot;
        _maxStack = maxStack;
    }
    
    public async Task<List<Item>> GetAllItemsAsync()//모든 아이템 목록을 비동기적으로 가져오는 메서드
    {
        return await _itemDataSource.LoadAllItemsAsync();
  
    }

    public async Task<Item?> GetItemByIdAsync(int itemId)//특정 아이템을 비동기적으로 검색하는 메서드
    {
        List<Item> allItems = await GetAllItemsAsync();
        Item ? item =  allItems.FirstOrDefault(item => item.Id == itemId);
        return item;
    }
    
    // 인벤토리에 없는 아이템을 추가할 경우 maxSlot 수를 초과할 수 없음
    // 하나의 아이템당 총 갯수(count)는 maxStack을 초과할 수 없음(기존 아이템에 추가할 때도 적용)
    // 위 조건이 모두 충족될 때만 아이템을 추가하며, 성공시 true, 실패시 fales를 반환
    
    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> currentItems = await GetAllItemsAsync(); //아이템 목록
        Item? existingItem = currentItems.FirstOrDefault(i => i.Id == item.Id); // 가지고 있는 아이템

        if (existingItem != null)
        {
            if (existingItem.Count + item.Count > _maxSlot)
            {
                return false;
            }
            
            existingItem.Count += item.Count ;
        }
        else
        {
            if (currentItems.Count > _maxStack)
            {
                return false;
            }

            if (item.Count > _maxStack)
            {
                return false;
            }
            
            currentItems.Add(item);
        }
        await _itemDataSource.SaveAllItemsAsync(currentItems);

        return true;
    }
  
}