using CsharpStudy._2hakgi.Assignment.Model_Repository.Models;

namespace CsharpStudy._2hakgi.Assignment.Model_Repository.Data.DataSources;

public class MockItemDataSource: IItemDataSource
{
    private List<Item> _items = [
        new Item(1, "Sword", 10),
        new Item(2, "Shield", 10)
    ];

    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        throw new NotImplementedException();
    }
}