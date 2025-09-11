namespace CsharpStudy.DataSource1;

public class InventoryRepository : IInventoryRepository
{
    private JsonFileItemData  _jsonFileItem;
    private int MaxSlot { get; set; }
    private int MaxStack { get; set; }

    public InventoryRepository(JsonFileItemData jsonFileItem, int maxSlot, int maxStack)
    {
        _jsonFileItem = jsonFileItem;
        MaxSlot = maxSlot;
        MaxStack = maxStack;
    }
    
    public Task<List<Item>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItemByIdAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddItemAsync(Item item)
    {
        throw new NotImplementedException();
    }
}