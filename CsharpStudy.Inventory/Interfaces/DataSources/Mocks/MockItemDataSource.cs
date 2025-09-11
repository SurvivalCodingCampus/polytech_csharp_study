using CsharpStudy.Inventory.Models;

namespace CsharpStudy.Inventory.Interfaces.DataSources.Mocks;

public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items = new List<Item>
    {
        new Item(1, "Sword", 1),
        new Item(2, "Shield", 2),
    };
    
    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items = items;
    }
}