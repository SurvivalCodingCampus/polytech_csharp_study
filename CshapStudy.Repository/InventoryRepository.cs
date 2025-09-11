using System.Runtime.InteropServices.ComTypes;

namespace CshapStudy.Repository;
using CshapStudy.Repository;

public class InventoryRepository : IInvetoryRepository
{
    public IItemDataSource itemDataSource {get; set;}
    public int MaxSlot { get;}
    public int MaxStock { get; set; }

    private List<Item> _items = new List<Item>();
    
    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStock)
    {
        this.itemDataSource = itemDataSource;
        MaxSlot = maxSlot;
        MaxStock = maxStock;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return _items = await itemDataSource.LoadAllItemAsync();
    }
    
    // async : 비동기
    public async Task<Item?> GetItemByldAsync(int itemId)
    {
        return _items.Find(i => i.Id == itemId);
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        // 반환값이 Task일 때 await를 해서 비동기작동되게 해야함
        // 비동기 call 비동기 
        Item tmpItem = await GetItemByldAsync(item.Id);
        if (tmpItem == null)
        {
            // 슬롯의 크기 확인
            if (_items.Count >= MaxSlot)
            {
                return false;
            }
            // Stack의 크기 확인
            if (item.Count > MaxStock)
            {
                item.Count = MaxStock;
            }
            _items.Add(item);
        }
        else
        {
            item.Count += tmpItem.Count;
            // Stack의 크기 확인
            if (item.Count > MaxStock)
            {
                item.Count = MaxStock;
                
            }
            _items.Insert(item.Id, item);
        }
        
        await itemDataSource.SaveAllItemsAsync(_items);
        return true;
    }
}