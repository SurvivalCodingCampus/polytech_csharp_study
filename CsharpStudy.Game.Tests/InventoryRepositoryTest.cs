using CshapStudy.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{
    [Test]
    public async Task 인벤토리_초기화_및_로드()
    {
        // Glven
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));
        items.Add(new Item(1, "Shield", 1));

        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        await mockItemDataSource.SaveAllItemsAsync(items);

        // When
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 2, 2);

        List<Item> result = await inventory.GetItemsAsync();

        // Then

        //Assert.That(result[0].Name, Is.EqualTo("Sword"));
        //Assert.That(result[1].Name, Is.EqualTo("Shield"));
        Assert.That(result, Is.EqualTo(items));
    }

    [Test]
    public async Task 새로운_아이템_추가_True()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));
        items.Add(new Item(1, "Shield", 1));

        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        await mockItemDataSource.SaveAllItemsAsync(items);

        // maxSlot 여유있게 선언
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 5, 2);

        items = await inventory.GetItemsAsync();

        // Given
        Item itemAdd = new Item(2, "Potion", 1);
        bool isAddItem = await inventory.AddItemAsync(itemAdd);

        // Then
        // 1. 저장 성공여부
        Assert.That(isAddItem, Is.True);
        items = await inventory.GetItemsAsync();
        // 2. Potion 목록 확인
        Assert.That(items[2].Name, Is.EqualTo("Potion"));
        Assert.That(await inventory.GetItemByldAsync(2), Is.EqualTo(itemAdd));

        // 3. 아이템 종류 수 확인
        Assert.That(items.Count, Is.EqualTo(3));
    }

    [Test]
    public async Task 기존_아이템_개수_증가_True()
    {
        // Glven
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));

        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        await mockItemDataSource.SaveAllItemsAsync(items);
        
        // maxStack 20
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 2, 20);
        await inventory.GetItemsAsync();
        
        // 목록에 있는 아이템 다시 저장
        bool isAddItem = await inventory.AddItemAsync(items[0]);
        
        // Then
        // 1. 저장 성공여부
        Assert.That(isAddItem, Is.True);
        items = await inventory.GetItemsAsync();
        
        // 2. 추가된 개수 확인
        Assert.That(items[0].Count, Is.EqualTo(2));
    }

    [Test]
    public async Task 새로운_아이템_추가_False_maxSlot()
    {
        // Glven
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));
        items.Add(new Item(1, "Shield", 1));

        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        await mockItemDataSource.SaveAllItemsAsync(items);
        
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 2, 2);
        await inventory.GetItemsAsync();

        // 포션 추가 시도
        Item itemAdd = new Item(2, "Potion", 1);
        bool isAddItem = await inventory.AddItemAsync(itemAdd);

        // Then
        // 1. 저장 성공여부
        Assert.That(isAddItem, Is.False);
        items = await inventory.GetItemsAsync();
        
        // 2. 아이템 종류 수 확인
        Assert.That(items.Count, Is.EqualTo(2));
        
        // 3. Potion 목록 확인
        Assert.That(await inventory.GetItemByldAsync(itemAdd.Id), Is.Null);
    }

    [Test]
    public async Task 아이템_개수_증가_False_maxStack()
    {
        
        // Glven
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Potion", 99));

        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        await mockItemDataSource.SaveAllItemsAsync(items);
        
        // maxStack 20
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 2, 99);
        await inventory.GetItemsAsync();
        
        // 목록에 있는 아이템 다시 저장
        bool isAddItem = await inventory.AddItemAsync(items[0]);
        
        // Then
        // 1. 저장 성공여부
        Assert.That(isAddItem, Is.True);
        
        // 2. 추가된 개수 확인
        items = await inventory.GetItemsAsync();
        Assert.That(items[0].Count, Is.EqualTo(99));
    }
}