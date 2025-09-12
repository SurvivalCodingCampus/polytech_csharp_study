namespace CsharpStudy.DataSource1;

public interface IItemDataSource
{
    public Task<List<Item>> LoadAllItemsAsync();
    public Task SaveAllItemAsync(List<Item> items);
}