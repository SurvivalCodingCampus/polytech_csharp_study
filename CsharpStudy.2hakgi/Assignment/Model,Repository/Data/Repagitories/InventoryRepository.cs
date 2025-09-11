using CsharpStudy._2hakgi.Assignment.Model_Repository.Models;

namespace CsharpStudy._2hakgi.Assignment.Model_Repository.Data.DataSources;

public class InventoryRepository: IInventoryRepository
{
    public IItemDataSource ItemDataSource { get; set; }
    public int MaxSlot { get; set; }    // 인벤토리 최대 슬롯 수 
    public int MaxStack { get; set; }   // 아이템당 최대 갯수

    public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
    {
        ItemDataSource = dataSource;
        MaxSlot = maxSlot;
        MaxStack = maxStack;
    }

    public Task<List<Item>> GetItemsAsync()
    {
        // 모든 아이템 목록을 비동기적으로 가져오는 메서드.
        throw new NotImplementedException();
    }

    public Task<Item?> GetItemByIdAsync(int itemId)
    {
        // 특정 아이템을 비동기적으로 검색하는 메서드.
        throw new NotImplementedException();
    }

    public Task<bool> AddItemAsync(Item item)
    {
        // 아이템을 인벤토리에 추가하는 메서드. 성공시 true, 실패시 false
        // 규칙1. 인벤토리에 없는 아이템을 추가할 경우 maxSlot을 초과할 수 없음
        // 규칙2. 하나의 아이템당 총 갯수(count)는 maxStack을 초과할 수 없음(기존 아이템 추가에도 적용)
        // 규칙3. 위 조건을 모두 충족할 때만 아이템 추가, 성공시 True 실패시 False 반환 
        
        throw new NotImplementedException();
    }
}