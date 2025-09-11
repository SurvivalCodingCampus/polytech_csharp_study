using CsharpStudy._2hakgi.Assignment.Model_Repository.Models;

namespace CsharpStudy._2hakgi.Assignment.Model_Repository.Data.DataSources;

public interface IInventoryRepository
{
    // Task<List<Item>> GetItemsAsync(): 모든 아이템 목록을 비동기적으로 가져오는 메서드.
    abstract Task<List<Item>> GetItemsAsync();
    
    // Task<Item?> GetItemByIdAsync(int itemId): 특정 아이템을 비동기적으로 검색하는 메서드.
    abstract Task<Item?> GetItemByIdAsync(int itemId);
    
    // Task<bool> AddItemAsync(Item item): 아이템을 인벤토리에 추가하는 메서드. 성공시 true, 실패시 false
    abstract Task<bool> AddItemAsync(Item item);
}