using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpStudy.Repository.Data.DataSources;
using CsharpStudy.Repository.Data.Repositories;
using CsharpStudy.Repository.Models;
using NUnit.Framework;

namespace CsharpStudy.Repository.Data.Repositories.Tests.Data.Repositories;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{
    private Task<List<Item>> _dataSource;

    [Test]
    public async Task 인벤토리_초기화_및_로드()
    {
        MockItemDataSource dataSources = new MockItemDataSource();
        InventoryRepository inventory = new InventoryRepository(dataSources, 2, 10);
        
        List<Item> inventoryRepository = await inventory.GetItemsAsync();
        
        Assert.That(inventoryRepository.Exists(i => i.Name == "Sword"), Is.True);
        Assert.That(inventoryRepository.Exists(i => i.Name == "Shield"), Is.True);
        
        // Given: MockItemDataSource에 "Sword"와 "Shield"가 준비되어 있습니다.
        // When: InventoryRepository를 초기화하고 아이템 목록을 로드합니다.
        // Then: 인벤토리에는 "Sword"와 "Shield" 두 아이템이 포함되어야 합니다.
    }

    [Test]
    public async Task 새로운_아이템_추가_성공()
    {
        MockItemDataSource dataSources = new MockItemDataSource();
        InventoryRepository inventory = new InventoryRepository(dataSources, 3, 4);
        await inventory.AddItemAsync(new Item(3, "Potion", 1));
        
        List<Item> inventoryRepository = await inventory.GetItemsAsync();

        Assert.That(inventoryRepository.Count, Is.EqualTo(3));
        Assert.That(inventoryRepository.Any(i => i.Name == "Potion"), Is.True);
        
        // Given: 인벤토리에 "Potion" 아이템이 없습니다. maxSlot에는 여유가 있습니다.
        // When: "Potion" 아이템을 인벤토리에 추가합니다.
        // Then: 인벤토리의 총 아이템 종류 수가 3개로 늘어나고, "Potion"이 목록에 있어야 합니다
    }

    [Test]
    public async Task 기존_아이템_개수_증가()
    {
        MockItemDataSource dataSources = new MockItemDataSource();
        InventoryRepository inventory = new InventoryRepository(dataSources, 4, 10);
        await inventory.AddItemAsync(new Item(2, "Swrod", 2));
        
        Item item = await inventory.GetItemAsync(1);
        
        Assert.That(item?.Count, Is.EqualTo(2));
        
        // Given: "Sword" 아이템이 인벤토리에 1개 있습니다. maxStack은 20입니다.
        // When: "Sword" 아이템을 다시 1개 추가합니다.
        // Then: "Sword" 아이템의 개수가 2개로 증가해야 합니다.
    }

    [Test]
    public async Task 새로운_아이템_추가_실패()
    {  
        MockItemDataSource dataSources = new MockItemDataSource();
        InventoryRepository inventory = new InventoryRepository(dataSources, 2, 10);
        bool tell = await inventory.AddItemAsync(new Item(3, "Potion", 1));
        
        Assert.That(tell, Is.False);
        
        // Given: 인벤토리의 maxSlot이 2이며, 현재 "Sword"와 "Shield" 두 아이템이 있습니다.
        // When: "Potion" 아이템을 인벤토리에 추가하려 시도합니다.
        // Then: AddItemAsync 메서드는 false를 반환해야 하며, "Potion"은 인벤토리 목록에 추가되지 않아야 합니다.

    }

    [Test]
    public async Task 아이템_개수_증가_실패()
    {
        MockItemDataSource dataSources = new MockItemDataSource();
        InventoryRepository inventory = new InventoryRepository(dataSources, 2, 99);
        
        bool tell = await inventory.AddItemAsync(new Item(1, "Potion", 99));
        
        Assert.That(tell, Is.False);
        
        // Given: "Potion" 아이템이 인벤토리에 99개 있습니다. maxStack은 99입니다.
        // When: "Potion" 아이템을 다시 1개 추가하려 시도합니다.
        // Then: AddItemAsync 메서드는 false를 반환해야 하며, "Potion"의 개수는 여전히 99개여야 합니다.
    }
}