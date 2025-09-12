using _250911.Data.DataSources;
using _250911.Data.Repositories;
using _250911.Models;

namespace _250911;

public class MockItemDataSource:IItemDataSource
{
    //private List<Item> _items=[];
    
    private List<Item> _items = new List<Item>
    {
        { new Item(10, "Sword", 1) },
        { new Item(20, "Shield", 2) },
    };

    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        this._items = items;
    }

}