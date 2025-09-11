using CshapStudy.DataSource0911.Models;
namespace CshapStudy.DataSource0911.Data;

public interface IItemDataSource 
{
    Task<List<Item>> LoadAllItemsAsync();
    Task SaveAllItemsAsync(List<Item> items);
    
  }

