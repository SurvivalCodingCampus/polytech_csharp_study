using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.DataSources;

public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items = new List<Item>
    {
        new Item(1, "Sword", 2),
        new Item(1, "Shield", 10)
    };

    public async Task<List<Item>> LoadItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemAsync(List<Item> items)
    {
       _items = items;
    }
}