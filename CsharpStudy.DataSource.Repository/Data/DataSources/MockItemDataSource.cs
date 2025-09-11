using CsharpStudy.DataSource.Repository.Models;

namespace CsharpStudy.DataSource.Repository.Data.DataSources;

public class MockItemDataSource : IItemDataSource
{
    public List<Item> Items { get; set; } = [];


    public async Task<List<Item>> LoadAllItemsAsync() // 아이템 데이터를 읽어오는 메서드 
    {
        return Items;
    }

    public async Task SaveAllItemAsync(List<Item> items) // 아이템 데이터를 저장하는 메서드 
    {
        Items = items;
    }
}