namespace CshapStudy.Repository;

public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items = [];

    public async Task<List<Item>> LoadAllItemAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items = items;
    }
}