using System.Collections.Generic;
using System.Threading.Tasks;
using CsharpStudy.Repository.Data.DataSources;
using CsharpStudy.Repository.Data.Repository;
using CsharpStudy.Repository.Models;
using NUnit.Framework;

namespace CsharpStudy.Repository.Tests.Data.Repository;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{

    [Test]
    public async Task Test_Inventory_Initialization_And_Load()
    {
        // Given: MockItemDataSource에 "Sword"와 "Shield"가 준비되어 있습니다.
        var mockDataSource = new MockItemDataSource();
        var initialItems = new List<Item>
        {
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 1)
        };
        await mockDataSource.SaveAllItemsAsync(initialItems);
        
        // When: InventoryRepository를 초기화하고 아이템 목록을 로드합니다.
        InventoryRepository repository = new InventoryRepository(mockDataSource, 10, 10);
        var loadItems = await repository.GetItemsAsync();
        
        // Then: 인벤토리에는 "Sword"와 "Shield" 두 아이템이 포함되어야 합니다. 
        Assert.That(loadItems.Count, Is.EqualTo(2));
        
        var sword = repository.GetItemByIdAsync(1);
        Assert.That(sword, Is.Not.Null);
        
        var shield = repository.GetItemByIdAsync(2);
        Assert.That(shield, Is.Not.Null);
        
    }

    [Test]
    public async Task Test_Add_New_Item()
    {
        // Given: 인벤토리에 "Potion" 아이템이 없습니다. maxSlot에는 여유가 있습니다.
        var mockDataSource = new MockItemDataSource();
        var initialItems = new List<Item>
        {
            new Item(1, "Sword", 1),
        };
        await mockDataSource.SaveAllItemsAsync(initialItems);
        InventoryRepository repository = new InventoryRepository(mockDataSource, 10, 10);
        
        // When: "Potion" 아이템을 인벤토리에 추가합니다.
        Item additem = new Item(2, "Potion", 2);
        await repository.AddItemAsync(additem);
        
        // Then: 인벤토리의 총 아이템 종류 수가 3개로 늘어나고, "Potion"이 목록에 있어야 합니다.
        var loadItems = await repository.GetItemsAsync();
        Assert.That(loadItems.Count, Is.EqualTo(2));
        
        var potion = repository.GetItemByIdAsync(2);
        Assert.That(potion, Is.Not.Null);
    }

    [Test]
    public async Task Add_Existing_Items()
    {
        // Given: "Sword" 아이템이 인벤토리에 1개 있습니다. "Sword"의 maxStack은 20입니다.
        var mockDataSource = new MockItemDataSource();
        var initialItems = new List<Item>
        {
            new Item(1, "Sword", 1),
        };
        await mockDataSource.SaveAllItemsAsync(initialItems);
        InventoryRepository repository = new InventoryRepository(mockDataSource, 10, 20);
        
        // When: "Sword" 아이템을 다시 1개 추가합니다.
        Item additem = new Item(1, "Sword", 1);
        var result = await repository.AddItemAsync(additem);
        
        // Then: "Sword" 아이템의 개수가 2개로 증가해야 합니다.
        Assert.That(result, Is.True);
        
        var sword = await repository.GetItemByIdAsync(1);
        Assert.That(sword, Is.Not.Null);
        Assert.That(sword.Count, Is.EqualTo(2));
        
    }

}