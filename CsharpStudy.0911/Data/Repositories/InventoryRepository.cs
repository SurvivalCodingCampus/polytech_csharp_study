using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpStudy._0911
{
    public class InventoryRepository : IInvetoryRepository
    {
        private readonly IItemDataSource _dataSource;
        private readonly int _maxSlot;
        private readonly int _maxStack;
        private List<Item> _items = new();

        public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
        {
            _dataSource = dataSource;
            _maxSlot = maxSlot;
            _maxStack = maxStack;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            _items = await _dataSource.LoadAllItemsAsync();
            return _items;
        }

        public async Task<Item?> GetItemByIdAsync(int itemId)
        {
            return (await GetItemsAsync()).FirstOrDefault(i => i.Id == itemId);
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            var items = await GetItemsAsync();
            var existing = items.FirstOrDefault(i => i.Id == item.Id);

            if (existing != null)
            {
                if (existing.Count + item.Count > _maxStack) return false;
                existing.IncreaseCount(item.Count);
            }
            else
            {
                if (items.Count >= _maxSlot) return false;
                items.Add(item);
            }

            await _dataSource.SaveAllItemsAsync(items);
            return true;
        }
    }
}