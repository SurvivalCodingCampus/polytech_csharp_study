using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Csharp.Repository.Data.DataSources;
using Csharp.Repository.Models;
using CsharpStudy.Repository.Data.Repagitories;
using NUnit.Framework;

namespace CsharpStudy.Repository.Tests.Data.Repagitories;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{
    [Test]
    public async Task InitInventory()
    {
        // [Glven] Sword, Shield 준비, 추가
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));
        items.Add(new Item(1, "Shield", 1));

        MockItemDataSource itemDataSource = new MockItemDataSource();
        itemDataSource.SaveAllItemsAsync(items); // 인벤토리에 아이템 추가하고 저장

        // [When] Inventoryrepository 초기화
        InventoryRepository repository = new InventoryRepository(itemDataSource, 10, 10);

        // [Then] 아이템 목록 로드, 비교
        var loaded = await repository.GetItemsAsync();
        Assert.That(loaded, Is.EqualTo(items));
    }    
    
    [Test]
    public async Task AddNewItemSuccess()
    {
        // [Glven] 새로운 아이템 Potion 추가, maxSlot 여유 
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));
        items.Add(new Item(1, "Shield", 1));
        
        MockItemDataSource itemDataSource = new MockItemDataSource();
        itemDataSource.SaveAllItemsAsync(items); // 인벤토리에 아이템 추가하고 저장
        
        // [When] Postion을 인벤토리 추가
        Item potion = new Item(2, "Potion", 1);
        InventoryRepository repository = new InventoryRepository(itemDataSource, 10, 10);
        repository.AddItemAsync(potion);
                    
        // [Then] Potion이 목록에 있어야 함 
        Assert.That(repository.GetItemByIdAsync(potion.ItemId), Is.Not.Null);
        
        // [Then] 인벤토리 아이템 종류 3개로 증가
        var loaded = await repository.GetItemsAsync();
        Assert.That(loaded.Count, Is.EqualTo(3));
    }
    
    [Test]
    public async Task AddExistItemSuccess()
    {
        Item sword = new Item(0, "Sword", 1);
        
        // [Glven] Sword 아이템이 인벤토리에 존재, MaxStack은 20
        List<Item> items = new List<Item>();
        items.Add(sword);
        
        MockItemDataSource itemDataSource = new MockItemDataSource();
        itemDataSource.SaveAllItemsAsync(items); // 인벤토리에 아이템 추가하고 저장
        
        // [When] Sword 아이템 1개 추가
        InventoryRepository inventory = new InventoryRepository(itemDataSource, 10, 10);
        inventory.AddItemAsync(sword);
        
        // [Then] Sword 아이템 개수 2개로 증가해야함
        Item temp = await inventory.GetItemByIdAsync(sword.ItemId);
        Assert.That(temp!.ItemId, Is.EqualTo(sword.ItemId)); // !: null이 아님을 확실하게 알리기
        Assert.That(temp!.ItemCount, Is.EqualTo(2));
    }
    
    [Test]
    public async Task AddNewItemFail()
    {
        // [Glven] maxSlot은 2, Sword/Sheild 가 있음
        List<Item> items = new List<Item>();
        items.Add(new Item(0, "Sword", 1));
        items.Add(new Item(1, "Shield", 1));
        
        MockItemDataSource itemDataSource = new MockItemDataSource();
        itemDataSource.SaveAllItemsAsync(items); // 인벤토리에 아이템 추가하고 저장
        
        // [When] Potion 인벤토리에 추가 시도
        InventoryRepository inventory = new InventoryRepository(itemDataSource, 2, 2);

        Item potion = new Item(2, "Potion", 1);
        bool result = await inventory.AddItemAsync(potion);
        
        // [Then] false 반환 여부 확인
        Assert.That(result, Is.EqualTo(false));
    }
    
    [Test]
    public async Task AddExistItemFail()
    {
        int potionId = 0;
        
        // [Glven] maxSlot은 2, Sword/Sheild 가 있음
        List<Item> items = new List<Item>();
        items.Add(new Item(potionId, "Potion", 99));
        
        MockItemDataSource itemDataSource = new MockItemDataSource();
        itemDataSource.SaveAllItemsAsync(items); // 인벤토리에 아이템 추가하고 저장
        
        // [When] Potion 1개 인벤토리에 추가 시도
        InventoryRepository inventory = new InventoryRepository(itemDataSource, 99, 99);
        bool result = await inventory.AddItemAsync(new Item(potionId, "Potion", 1));
        
        // [Then] false 반환 여부 확인
        Assert.That(result, Is.EqualTo(false));
        
        // [Then] Potion 개수 99개인지 확인
        Item? temp = await inventory.GetItemByIdAsync(potionId);
        Assert.That(temp.ItemCount, Is.EqualTo(99));
    }
}
