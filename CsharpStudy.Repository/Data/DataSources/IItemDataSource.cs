using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.DataSources;

public interface IItemDataSource
{
    // 아이템 데이터를 읽어오는 메서드
    public Task<List<Item>> LoadItemsAsync();
    
    // 아이템 데이터를 저장하는 메서드
    public Task SaveAllItemAsync(List<Item> items);
}