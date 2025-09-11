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
        
        // 아이템 리스트 개수가 maxSlot 보다 작을 때만 아이템 추가 가능
        if (inventory.Count < maxSlot)
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