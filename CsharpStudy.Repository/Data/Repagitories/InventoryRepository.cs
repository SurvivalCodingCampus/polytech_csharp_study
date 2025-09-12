using Csharp.Repository.Data.DataSources;
using Csharp.Repository.Data.Repagitories;
using Csharp.Repository.Models;

namespace CsharpStudy.Repository.Data.Repagitories;

public class InventoryRepository: IInventoryRepository
{
    public IItemDataSource ItemDataSource { get; set; }
    public int MaxSlot { get; set; }    // 인벤토리 최대 슬롯 수 
    public int MaxStack { get; set; }   // 아이템당 최대 갯수
    private List<Item> _items = new List<Item>();

    public InventoryRepository(MockItemDataSource dataSource, int maxSlot, int maxStack)
    {
        ItemDataSource = dataSource;
        MaxSlot = maxSlot;
        MaxStack = maxStack;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        // 모든 아이템 목록을 비동기적으로 가져오는 메서드.
        return await ItemDataSource.LoadAllItemsAsync();
    }

    public async Task<Item> GetItemByIdAsync(int itemId)
    {
        // 특정 아이템을 비동기적으로 검색하는 메서드.
        return _items.Find(item => item.ItemId == itemId);
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        // 아이템 목록 가져오기
        _items = await GetItemsAsync();
        
        // 아이템 목록에서 아이템 검색 
        Item tempItem = await GetItemByIdAsync(item.ItemId);
        if (tempItem == null)
        {
            // 인벤토리에 처음 추가되는 아이템인 경우
            // 규칙1. 인벤토리에 없는 아이템을 추가할 경우 maxSlot을 초과할 수 없음
            if (_items.Count >= MaxSlot) return false;
            // 규칙2. 하나의 아이템당 총 갯수(count)는 maxStack을 초과할 수 없음(기존 아이템 추가에도 적용)
            //          * 총 갯수가 maxStack을 초과하는 경우 MaxStack까지만 허용하기
            if (item.ItemCount > MaxStack) return false;
            // 인벤토리에 추가
            _items.Add(item);
        }
        else
        {
            // 인벤토리에 이미 있는 아이템인 경우
            // 규칙2. 하나의 아이템당 총 갯수(count)는 maxStack을 초과할 수 없음(기존 아이템 추가에도 적용)
            //          * 총 갯수가 maxStack을 초과하는 경우 MaxStack까지만 허용하기
            item.ItemCount += tempItem.ItemCount;
            if (item.ItemCount > MaxStack) return false;
            
            // 규칙3. 위 조건을 모두 충족할 때만 아이템 추가, 성공시 True 실패시 False 반환 
            // 원래 있는 아이템 자리에 새로운 아이템 추가하기
            var idx = _items.IndexOf(tempItem);     
            _items[idx] = item;
        }
        // 새로운 아이템 목록 저장하기
        await ItemDataSource.SaveAllItemsAsync(_items); 
        return true;
    }
}