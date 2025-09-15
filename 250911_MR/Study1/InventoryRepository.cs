namespace _250911_MR.Study1;

//생성자로부터 IItemDataSource 와 int maxSlot (슬롯 갯수), int maxStack(아이템당 최대 갯수)를 주입받을 것
// AddItemAsync()는 다음 규칙을 따름
/*인벤토리에 없는 아이템을 추가할 경우 maxSlot 수를 초과할 수 없음
 하나의 아이템당 총 갯수(count)는 maxStack을 초과할 수 없음(기존 아이템에 추가할 때도 적용)
 위 조건이 모두 충족될 때만 아이템을 추가하며, 성공 시 true, 실패 시 false를 반환*/

public class InventoryRepository : IInventoryRepository
{
        private IItemDataSource _dataSource;
        public int _maxSlot;
        public int _maxStack;
        
        private List<Item> items = new List<Item>();
        
        public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
        {
            _dataSource = dataSource;
            _maxSlot = maxSlot;
            _maxStack = maxStack;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _dataSource.LoadAllItemsAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int itemId)
        {
            List<Item> allItems = await _dataSource.LoadAllItemsAsync();
            return allItems.FirstOrDefault(i => i.Id == itemId);
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            // 인벤토리에 없으면 인벤토리에 추가
            // 단 maxSlot을 초과할 수 없음
            List<Item> allItems = await _dataSource.LoadAllItemsAsync();
            allItems.Add(item);
            bool hasItme = allItems.Any(e => e.Id == item.Id);

            if (hasItme)
            {
                
                Item findItem=allItems.First(e=>e.Id==item.Id);
                if (findItem.Count >= _maxStack)
                {
                    return false;
                }
                findItem.Count += item.Count;

                if (findItem.Count > _maxStack)
                {
                    findItem.Count = _maxStack;
                }

                return true;
            }
            else
            {
                //인벤토리에 있으면 Count 증가
                //단 maxStack을 초과할 수 없음
                if (allItems.Count >= _maxSlot)
                {
                    return false;
                }
                allItems.Add(item);
            }
            await _dataSource.SaveAllItemsAsync(allItems);
            return true;
        }
}