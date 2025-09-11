using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsharpStudy._0911;

public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items = [];
    
    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items = items;
    }
}