using NUnit.Framework;
using CsharpStudy.DataSource1;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class InventoryRepositoryTests
{
    [Test]
    [Description("인벤토리 초기화 및 로드")]
    public async Task Test1()
    {
        var mockData = new MockItemDataSource(new List<Item>
        {
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 1)
        });

        var repo = new InventoryRepository(mockData, maxSlot: 10, maxStack: 99);

        var items = await repo.GetItemsAsync();

        Assert.That(items.Count(), Is.EqualTo(2));
        Assert.That(items.Any(i => i.name == "Sword"));
        Assert.That(items.Any(i => i.name == "Shield"));
    }

    [Test]
    [Description("새로운 아이템 추가(성공)")]
    public async Task Test2()
    {
        var mockData = new MockItemDataSource(new List<Item>
        {
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 1)
        });

        var repo = new InventoryRepository(mockData, maxSlot: 10, maxStack: 99);

        var result = await repo.AddItemAsync(new Item(3, "Potion", 1));
        var items = await repo.GetItemsAsync();

        Assert.That(result);
        Assert.That(items.Count(), Is.EqualTo(3));
        Assert.That(items.Any(i => i.name == "Potion"));
    }

    [Test]
    [Description("새로운 아이템 추가(성공-item.count 증가)")]
    public async Task Test3()
    {
        var mockData = new MockItemDataSource(new List<Item>
        {
            new Item(1, "Sword", 1)
        });

        var repo = new InventoryRepository(mockData, maxSlot: 10, maxStack: 20);

        var result = await repo.AddItemAsync(new Item(1, "Sword", 1));
        var items = await repo.GetItemsAsync();

        var sword = items.FirstOrDefault(i => i.id == 1);

        Assert.That(result);
        Assert.That(sword,Is.Not.Null);
        // Assert.That(sword.count,Is.EqualTo(2));
    }

    [Test]
    [Description("새로운 아이템 추가(실패-MaxSlot 초과)")]
    public async Task Test4()
    {
        var mockData = new MockItemDataSource(new List<Item>
        {
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 1)
        });

        var repo = new InventoryRepository(mockData, maxSlot: 2, maxStack: 99);

        var result = await repo.AddItemAsync(new Item(3, "Potion", 1));
        var items = await repo.GetItemsAsync();

        Assert.That(result,Is.False);
        Assert.That(items.Count(), Is.EqualTo(2));
        Assert.That(items.Any(i => i.name == "Potion"), Is.False);
    }
    
    [Test]
    [Description("새로운 아이템 추가(실패-MaxStack 초과)")]
    public async Task Test5()
    {
        var mockData = new MockItemDataSource(new List<Item>
        {
            new Item(1, "Potion", 99)
        });

        var repo = new InventoryRepository(mockData, maxSlot: 10, maxStack: 99);

        var result = await repo.AddItemAsync(new Item(1, "Potion", 1));
        var items = await repo.GetItemsAsync();

        var potion = items.FirstOrDefault(i => i.id == 1);

        Assert.That(result, Is.False);
        Assert.That(potion.count, Is.EqualTo(99));
    }
}
