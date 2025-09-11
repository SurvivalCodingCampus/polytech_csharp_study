namespace CsharpStudy.DataSource1;

public interface IInventoryRepository
{
    // 모든 아이템 목록을 비동기적으로 가져옴
    Task<List<Item>> GetItemsAsync();
    
    // 특정 아이템을 비동기적으로 검색
    Task<Item?> GetItemByIdAsync(int itemId);
    
    // 아이템을 인벤토리에 추가(성공 시 true, 실패 시 false 반환)
    Task<bool> AddItemAsync(Item item);
}