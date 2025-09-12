namespace Csharp.Study.Model;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemsAsync();    // 아이템 데이터 읽기
    Task SaveAllItemsAsync(List<Item> items);    // 아이템 데이터 저장
}