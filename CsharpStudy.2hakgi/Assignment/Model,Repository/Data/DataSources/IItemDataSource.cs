using CsharpStudy._2hakgi.Assignment.Model_Repository.Models;
namespace CsharpStudy._2hakgi.Assignment.Model_Repository.Data.DataSources;

public interface IItemDataSource
{
    // Task<List<Item>> LoadAllItemsAsync() : 아이템 데이터를 읽어오는 메서드
    abstract Task<List<Item>> LoadAllItemsAsync();
    // Task SaveAllItemsAsync(List<Item> items) : 아이템 데이터를 저장하는 메서드 데이터를 읽어오는 메서드
    abstract Task SaveAllItemsAsync(List<Item> items);

}