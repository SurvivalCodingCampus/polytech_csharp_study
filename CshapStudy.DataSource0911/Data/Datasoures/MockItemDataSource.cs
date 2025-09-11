using CshapStudy.DataSource0911.Models;

namespace CshapStudy.DataSource0911.Data;
public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items = [];
    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items =  items;
    }

    
}