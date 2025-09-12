namespace Asynchronous.DataSources;

public class MockItemDataSource : IItemDataSource
{
    
    public List<Item> _items = new List<Item>
    {
        { new Item (0,"Sword", 1)},
        { new Item (1,"Shield", 1)}
        
    };
    
    /*private List<Item> _items = [];*/
    
    public async Task<List<Item>>LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items = items;
    }
}