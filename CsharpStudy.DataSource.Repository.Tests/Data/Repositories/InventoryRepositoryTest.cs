using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpStudy.DataSource.Repository.Data.DataSources;
using CsharpStudy.DataSource.Repository.Data.Repositories;
using CsharpStudy.DataSource.Repository.Models;
using NUnit.Framework;

namespace CsharpStudy.DataSource.Repository.Tests.Data.Repositories;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{
    [Test] // 1. 인벤토리 초기화 및 로드
    public async Task TestInventoryInitializationAndLoad()
    {
        //Given: MockItemDataSource에 "Sword"와 "Shield"가 준비되어 있습니다.

        MockItemDataSource mockItemDataSource = new MockItemDataSource(); // 객체 생성 
        List<Item> initialItems =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 3)
        ];
        mockItemDataSource.Items = initialItems;


        //When: InventoryRepository를 초기화하고 아이템 목록을 로드합니다.
        InventoryRepository inventoryRepository = new InventoryRepository(mockItemDataSource, 3, 5);

        List<Item> items = await inventoryRepository.GetItemsAsync();

        //Then: 인벤토리에는 "Sword"와 "Shield" 두 아이템이 포함되어야 합니다.

        Assert.That(items.Any(i => i.Name == "Sword"), Is.True);
        Assert.That(items.Any(i => i.Name == "Shield"), Is.True);
    }


    [Test] // 2. 새로운 아이템 추가 (성공)
    public async Task AddItem_WhenSlotIsAvailable_ShouldSucceed()
    {
        //Given: 인벤토리에 "Potion" 아이템이 없습니다. maxSlot에는 여유가 있습니다.
        MockItemDataSource mockItemDataSource = new MockItemDataSource(); // 객체 생성 
        List<Item> initialItems =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 3)
        ];
        mockItemDataSource.Items = initialItems;
        InventoryRepository inventoryRepository = new InventoryRepository(mockItemDataSource, 3, 5);

        //When: "Potion" 아이템을 인벤토리에 추가합니다.
        await inventoryRepository.AddItemAsync(new Item(3, "Potion", 1));

        List<Item> items = await inventoryRepository.GetItemsAsync();

        //Then: 인벤토리의 총 아이템 종류 수가 3개로 늘어나고, "Potion"이 목록에 있어야 합니다.
        Assert.That(items.Count, Is.EqualTo(3));
        Assert.That(items.Any(i => i.Name == "Potion"), Is.True);
    }

    [Test] // 3. 기존 아이템 개수 증가 (성공)
    public async Task IncreaseItemCount_WhenStackIsNotFull_ShouldSucceed()
    {
        //Given: "Sword" 아이템이 인벤토리에 1개 있습니다. maxStack은 20입니다.
        MockItemDataSource mockItemDataSource = new MockItemDataSource(); // 객체 생성 
        List<Item> initialItems =
        [
            new Item(1, "Sword", 1)
        ];
        mockItemDataSource.Items = initialItems;
        InventoryRepository inventoryRepository = new InventoryRepository(mockItemDataSource, 3, 20);

        //When: "Sword" 아이템을 다시 1개 추가합니다.

        await inventoryRepository.AddItemAsync(new Item(1, "Sword", 1));

        // Then: "Sword" 아이템의 개수가 2개로 증가해야 합니다.
        Assert.That((await inventoryRepository.GetItemByIdAsync(1))?.Count, Is.EqualTo(2));
        // null이 아닐때만 호출 > 안전한 호출 > 널이면 널값이 나옴 , 터지지 않음 
    }

    [Test] // 4. 새로운 아이템 추가 (실패 - maxSlot 초과)
    public async Task AddItem_WhenInventoryIsFull_ShouldFail()
    {
        //Given: 인벤토리의 maxSlot이 2이며, 현재 "Sword"와 "Shield" 두 아이템이 있습니다.
        MockItemDataSource mockItemDataSource = new MockItemDataSource(); // 객체 생성 
        InventoryRepository inventoryRepository = new InventoryRepository(mockItemDataSource, 2, 20);
        List<Item> initialItems =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 3)
        ];
        mockItemDataSource.Items = initialItems;

        //  When: "Potion" 아이템을 인벤토리에 추가하려 시도합니다.
        bool wasAdded = await inventoryRepository.AddItemAsync(new Item(3, "Potion", 1));
        
        //  Then: AddItemAsync 메서드는 false를 반환해야 하며, "Potion"은 인벤토리 목록에 추가되지 않아야 합니다.
        Assert.That(wasAdded, Is.False);
        Assert.That((await inventoryRepository.GetItemByIdAsync(3)), Is.Null);
        
    }

    [Test] // 5. 아이템 개수 증가 (실패 - maxStack 초과)
    public async Task IncreaseItemCount_WhenStackIsFull_ShouldFail()
    {
        //Given: "Potion" 아이템이 인벤토리에 99개 있습니다. "Potion"의 maxStack은 99입니다.
        MockItemDataSource mockItemDataSource = new MockItemDataSource(); // 객체 생성 
        List<Item> initialItems =
        [
            new Item(1, "Potion", 99)
        ];
        mockItemDataSource.Items = initialItems;
        InventoryRepository inventoryRepository = new InventoryRepository(mockItemDataSource, 2, 99);

        //  When: "Potion" 아이템을 다시 1개 추가하려 시도합니다.
        bool wasAdded = await inventoryRepository.AddItemAsync(new Item(1, "Potion", 1));

        // Then: AddItemAsync 메서드는 false를 반환해야 하며, "Potion"의 개수는 여전히 99개여야 합니다.
        Assert.That(wasAdded, Is.False);
        var itemAfterAttempt = await inventoryRepository.GetItemByIdAsync(1);
     
        Assert.That(itemAfterAttempt?.Count, Is.EqualTo(99));
        
    
    }
}