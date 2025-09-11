namespace CshapStudy.Repository;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemAsync();
    Task SaveAllItemsAsync(List<Item> items);
}