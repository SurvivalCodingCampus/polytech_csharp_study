namespace _250911_MR.Study1;

public interface IItemDataSource
{
    
    //아이템 데이터를 읽어오는 메서드
    Task<List<Item>> LoadAllItemsAsync();
    
    //아이템 데이터를 저장하는 메서드
    Task SaveAllItemsAsync(List<Item> items);

}