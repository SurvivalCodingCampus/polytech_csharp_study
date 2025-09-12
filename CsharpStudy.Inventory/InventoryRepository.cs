using CsharpStudy.Inventory.Interfaces.DataSources;
using CsharpStudy.Inventory.Interfaces.Repositories;
using CsharpStudy.Inventory.Models;

namespace CsharpStudy.Inventory;

public class InventoryRepository : IInventoryRepository
{
    // Properties
    public int MaxSlot { get; set; }
    public int MaxStack { get; set; }
    
    //Methods
    public InventoryRepository(IItemDataSource itemDataSource, int maxSlot, int maxStack)
    {
        _itemDataSource = itemDataSource;
        MaxSlot = maxSlot;
        MaxStack = maxStack;
    }
    
    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _itemDataSource.LoadAllItemsAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int itemId)
    {
        List<Item> itemsInInventory = await GetAllItemsAsync();
        
        if (itemsInInventory.FirstOrDefault(item => item.id == itemId) == null)
        {
            throw new NullReferenceException($"Item with id({itemId}) not found!");
        }
        
        return itemsInInventory.FirstOrDefault(item => item.id == itemId);
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        List<Item> itemsInInventory = await GetAllItemsAsync();

        if (itemsInInventory.FirstOrDefault(i => i.id == item.id) == null)
        {
            if (itemsInInventory.Count >= MaxSlot)
            {
                Console.WriteLine("Max slot reached! Couldn't pick item.");
                return false;
            }
            else
            {
                itemsInInventory.Add(item);
                await _itemDataSource.SaveAllItemsAsync(itemsInInventory);
                Console.WriteLine($"All items are successfully picked!");
                return true;
            }
        }
        else
        {
            Item targetItems = itemsInInventory.First(i => i.id == item.id);
            int itemCountBefore = item.count;

            if (targetItems.count + item.count > MaxStack)
            {
                int temp = MaxStack - targetItems.count;
                targetItems.count += temp;
                item.count = Math.Max(item.count - temp, 0);
            }
            else
            {
                targetItems.count += item.count;
                item.count = 0;
            }
            
            if (item.count > 0)
            {
                if (itemCountBefore == item.count)
                {
                    Console.WriteLine("You already maximum of it, and max inventory slot reached! Couldn't pick item.");
                    return false;
                }
                
                await _itemDataSource.SaveAllItemsAsync(itemsInInventory);
                Console.WriteLine($"Max stack reached! {item.count} of item dropped.");
                return true;
            }
            else
            {
                await _itemDataSource.SaveAllItemsAsync(itemsInInventory);
                Console.WriteLine($"All items are successfully picked!");
                return true;
            }
        }
        
        // Multiple instance version; need fixing! WIP!!!
        // if (itemsInInventory.FirstOrDefault(i => i.id == item.id) == null)
        // {
        //     if (itemsInInventory.Count >= MaxSlot) throw new ArgumentException("Max slot reached!");
        //     itemsInInventory.Add(item);
        //     return true;
        // }
        // else
        // {
        //     List<Item> targetItems = itemsInInventory.Where(i => i.id == item.id).ToList();
        //     int countToPut = item.count;
        //     
        //     foreach (Item i in targetItems)
        //     {
        //         if (i.count + countToPut > MaxStack)
        //         {
        //             int temp = MaxStack - i.count;
        //             i.count += temp;
        //             countToPut -= temp; // countToPut = Math.Max(countToPut - temp, 0);
        //             
        //         }
        //         else
        //         {
        //             i.count += countToPut;
        //             countToPut = 0;
        //         }
        //     }
        //     
        //     item.count = countToPut;
        // }
    }
    
    // Private fields
    private IItemDataSource _itemDataSource;
}