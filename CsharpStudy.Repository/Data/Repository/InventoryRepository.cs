using CsharpStudy.Repository.Data.DataSources;
using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.Repository;

public class InventoryRepository : IInventoryRepository
{
    private readonly IItemDataSource dataSource;
    private readonly int maxSlot;
    private readonly int maxStack;

    public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
    {
        this.dataSource = dataSource;
        this.maxSlot = maxSlot;
        this.maxStack = maxStack;
    }

    // 아이템 리스트 
    public async Task<List<Item>> GetItemsAsync()
    {
        return await dataSource.LoadAllItemsAsync();  // 아이템 리스트 불러오기
    }

    // 아이템 id로 아이템 찾기
    public async Task<Item?> GetItemByIdAsync(int itemId)
    {
        var items = await dataSource.LoadAllItemsAsync();
    
        foreach (var item in items)
        {
            // 현재 아이템의 ID가 찾으려는 ID와 일치하는지 확인
            if (item.Id == itemId)
            {
                // 일치하는 아이템 리턴
                return item;
            }
        }
    
        // 일치하는 아이템 없으면 null 리턴
        return null;
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        // 인벤토리에 없는 아이템을 추가할 경우 maxSlot 수를 초과할 수 없음
        // 하나의 아이템 당 총 갯수는 maxStack을 초과할 수 없음(기존 아이템 추가할 때도 마찬가지)
        // 위 조건이 모두 충족될 때만 아이템을 추가, 성공 시 ture, 실패 시 false
        
        var inventory = await dataSource.LoadAllItemsAsync();
        
        Item? existingItem = null;
        foreach (var inventoryItem in inventory)
        {
            if (inventoryItem.Id == item.Id)
            {
                existingItem = inventoryItem;
                break;
            }
        }
        
        // 아이템이 이미 존재하는 경우
        if (existingItem != null)
        {
            // 있던 개수랑 추가하는 개수의 합이 max보다 작으면 추가
            if (existingItem.Count + item.Count <= maxStack)
            {
                existingItem.Count += item.Count;
                await dataSource.SaveAllItemsAsync(inventory);
                return true;
            }
            else
            {
                return false;
            }
        }
        // 새로운 아이템인 경우
        else
        {
            
            // 아이템 리스트 개수가 max 보다 작을 때만 아이템 추가 가능 + 추가하는 개수가 max보다 작을 때
            if (inventory.Count < maxSlot && item.Count <= maxStack)
            {
                inventory.Add(item);
                await dataSource.SaveAllItemsAsync(inventory);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
   
        
    }
}