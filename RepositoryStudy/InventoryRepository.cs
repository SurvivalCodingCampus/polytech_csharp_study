namespace RepositoryStudy;

public class InventoryRepository : IInvetoryRepository
{
    private IItemDataSource dataSource;
    private int maxSlot;
    private int maxStack;
    private List<Item> items = new List<Item>();
    public int slot {private set; get;}
    //public int stack {private set; get;}

    public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
    {
        this.dataSource = dataSource;
        this.maxSlot = maxSlot;
        this.maxStack = maxStack;
    }

    //모든 아이템 목록을 비동기적으로 가져오는 메서드
    public async Task<List<Item>> GetItemsAsync()
    {
        return items = await dataSource.LoadAllItemsAsync();
    }
    //특정 아이템을 비동기적으로 검색하는 메서드
    public async Task<Item?> GetItemByIdAsync(int itemId)
    {
        Item? temp = items.FirstOrDefault(items => items.id == itemId);
        return temp;
    }
    //아이템을 인벤토리에 추가하는 메서드 성공시 true, 실패시 false
    public async Task<bool> AddItemAsync(Item item)
    {
        Item? temp = items.FirstOrDefault(items => items.id == item.id);

        if (temp != null)
        {
            if (maxStack > temp.count)
            {
                temp.count++;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (maxSlot > this.slot)
            {
                this.slot++;
                items.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}