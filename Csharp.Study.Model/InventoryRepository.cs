namespace Csharp.Study.Model;

public class InventoryRepository : IInventoryRepository
{
    private IItemDataSource _ds;
    private int _maxSlot;
    private int _maxStack;

    public InventoryRepository(IItemDataSource ds, int maxSlot, int maxStack)
    {
        _ds = ds ?? throw new ArgumentNullException(nameof(ds)); // 만약 ds가 null이면 예외, null이 아니면 _ds 할당
        if (maxSlot <= 0) throw new ArgumentOutOfRangeException(nameof(maxSlot));
        if (maxStack <= 0) throw new ArgumentOutOfRangeException(nameof(maxStack));

        _maxSlot  = maxSlot;
        _maxStack = maxStack;
    }

    public Task<List<Item>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Item?> GetItemByIdAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddItemAsync(Item item)
    {
        throw new NotImplementedException();
    }
}