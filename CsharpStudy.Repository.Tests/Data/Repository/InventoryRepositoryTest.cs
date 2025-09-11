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


}