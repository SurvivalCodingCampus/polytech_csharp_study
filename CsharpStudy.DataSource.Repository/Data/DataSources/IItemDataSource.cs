using CsharpStudy.DataSource.Repository.Models;

namespace CsharpStudy.DataSource.Repository.Data.DataSources;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemsAsync(); // 아이템 데이터를 읽어오는 메서드 
    Task SaveAllItemAsync(List<Item> items); // 아이템 데이터를 저장하는 메서드 
}