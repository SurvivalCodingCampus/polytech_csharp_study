namespace Asynchronous.DataSources;

public interface IInvetoryRepository
{
    Task<List<Item>> GetAllItemsAsync(); //모든 아이템 목록을 비동기적으로 가져오는 메서드
    
    Task<Item?> GetItemByIdAsync(int itemId);//특정 아이템을 비동기적으로 검색하는 메서드
    
    Task<bool> AddItemAsync(Item item);//아이템을 인벤토리에 추가하는 메서드, 성공시 true, 실패시 false
}