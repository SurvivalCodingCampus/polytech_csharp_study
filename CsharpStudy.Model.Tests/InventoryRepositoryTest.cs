using System.Collections.Generic; 
using System.Linq;                  
using System.Threading.Tasks;
using Csharp.Study.Model;
using NUnit.Framework;

namespace CsharpStudy.Model.Tests;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{

    [Test] //Test01
    public async Task InventoryRepository_LoadSwordShield()
    {
        //Given: MockItemDataSource에 "Sword"와 "Shield"가 준비되어야 한다.
        var ds = new MockItemDataSource();
        await ds.SaveAllItemsAsync(new List<Item>
        {
            new Item { Id = 1, Name = "Sword", Count = 1},
            new Item { Id = 2, Name = "Shield", Count = 1}
        });

        // When: InventoryRepository 초기화 후 아이템 목록 로드
        var repo = new InventoryRepository(ds, maxSlot: 10, maxStack: 100);
        var items = await repo.GetItemsAsync();

        // Then: Sword와 Shield가 포함되어 있어야 한다
        Assert.That(items.Any(item => item.Name == "Sword"));
        Assert.That(items.Any(item => item.Name == "Shield"));
    }
}