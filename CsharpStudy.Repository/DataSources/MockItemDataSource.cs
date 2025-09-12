using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.DataSources;

public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items = [];

    public MockItemDataSource()
    {
        // 초기값이 고정이면

        // {
        //     new Item(1, "사과 🍎", 10),
        //     new Item(2, "바나나 🍌", 5),
        //     new Item(3, "오렌지 🍊", 8)
        // };
    }

    public async Task<List<Item>> LoadAllItemsAsync()
    {
        return _items;
    }

    public async Task SaveAllItemsAsync(List<Item> items)
    {
        _items = items;
    }
}