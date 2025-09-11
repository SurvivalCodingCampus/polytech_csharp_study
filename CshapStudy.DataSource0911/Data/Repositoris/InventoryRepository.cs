using System.IO.Enumeration;
using CshapStudy.DataSource0911.Models;

namespace CshapStudy.DataSource0911.Data;

public class InventoryRepository : IInventoryRepository
{
    private IItemDataSource itemDataSource;
    private int maxSlot; // 슬롯최대갯수
    private int maxStack; //아이템최대갯수

    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStack)
    {
        this.itemDataSource = itemDataSource;
        this.maxSlot = maxSlot;
        this.maxStack = maxStack;
    }


    public async Task<List<Item>> GetItemsAsync()
    {
      
        return await itemDataSource.LoadAllItemsAsync();
        //모든아이템을 돌려주는거 모든거를 주는것
       

    }

    public async Task<Item?> GetItemAsync(int itemId)
    {

        List<Item> result = await itemDataSource.LoadAllItemsAsync();
      return   result.FirstOrDefault(i => i.Id == itemId);
        //원하는 아이디가 있는 아이텐을 돌려주는것
      


    }

    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> items = await itemDataSource.LoadAllItemsAsync();
        bool result = items.Any(i => i.Id == item.Id);

        if (!result && items.Count <= maxSlot)
        {
            // 인벤토리에 없는 아이템을 추가
            // maxSlot 수를 초과할 수 없음
            items.Add(item);
        }

        if (result != null)
        {
            return true;
        }

        if (item.Count <= maxSlot || item.Count <= maxStack)
        {
            await itemDataSource.SaveAllItemsAsync(items);
            

        } 
        return true;
        
    }
}