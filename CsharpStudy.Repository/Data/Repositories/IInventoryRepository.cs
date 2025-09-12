using CsharpStudy.Repository.Models;

namespace CsharpStudy.Repository.Data.Repositories;

public interface IInventoryRepository
{
    // 모든 아이템 목록을 비동기적으로 가져오는 메서드
    public Task<List<Item>> GetItemsAsync();
    
    // 특정 아이템을 비동기적으로 검색하는 메서드
    public Task<Item?> GetItemAsync(int itemld);
    
    // 아이템을 인벤토리에 추가하는 메서드 => 성공시 true 실패시 false
    public Task<bool> AddItemAsync(Item item);
}