namespace Csharp.Study.Model;

public interface IInventoryRepository
{
    Task<List<Item>> GetItemsAsync(); // 모든 아이템 가져오기

    Task<Item?> GetItemByIdAsync(int itemId); // 특정 아이템 검색

    Task<bool> AddItemAsync(Item item); // 아이템 추가
}