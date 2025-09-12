namespace RepositoryStudy;

public class MockItemDataSource : IItemDataSource
{
    public List<Item> _items = [];

    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items = items;
    }
}