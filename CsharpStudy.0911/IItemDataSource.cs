using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsharpStudy._0911;

public interface IItemDataSource
{
    Task<List<Item>> LoadAllItemsAsync();
    Task SaveAllItemsAsync(List<Item> items);
}