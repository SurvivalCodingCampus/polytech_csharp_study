using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using RepositoryStudy;
using NUnit.Framework.Legacy;


namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{

    [Test]
    public async Task 문제1번()
    {
        MockItemDataSource dataSource = new MockItemDataSource();
        dataSource._items.Add(new Item(1,"Sword",1));
        dataSource._items.Add(new Item(2,"Shield",1));
        IInvetoryRepository repository = new InventoryRepository(dataSource, 10, 10);
        
        List<Item> items = await repository.GetItemsAsync();
        Assert.That(items, Is.EqualTo(dataSource._items));

    }

    [Test] 
    public async Task 문제2번()
    {
        MockItemDataSource dataSource = new MockItemDataSource();
        dataSource._items.Add(new Item(1,"Sword",1));
        dataSource._items.Add(new Item(2,"Shield",1));
        IInvetoryRepository repository = new InventoryRepository(dataSource, 10, 10);
        
        Item item = new Item(3,"Potion",1);
        bool check = await repository.AddItemAsync(item);
        
        Assert.That(check, Is.True);
        Assert.That(item, Is.EqualTo(await repository.GetItemByIdAsync(3)));
    }

    [Test]
    public async Task 문제3번()
    {
        MockItemDataSource dataSource = new MockItemDataSource();
        dataSource._items.Add(new Item(1,"Sword",1));
        dataSource._items.Add(new Item(2,"Shield",1));
        IInvetoryRepository repository = new InventoryRepository(dataSource, 10, 20);
        
        List<Item> items = await repository.GetItemsAsync();//저장 및 얕은복사로 동기화
        
        Item item = new Item(1,"Sword",1);
        bool check = await repository.AddItemAsync(item);
        
        Assert.That(2, Is.EqualTo(repository.GetItemByIdAsync(1).Result.count));
        
    }

    [Test]
    public async Task 문제4번()
    {
        MockItemDataSource dataSource = new MockItemDataSource();
        IInvetoryRepository repository = new InventoryRepository(dataSource, 2, 10);
        List<Item> items = await repository.GetItemsAsync();//저장 및 얕은복사로 동기화
        
        Item item_1 = new Item(1,"Sword",1);
        Item item_2 = new Item(2,"Shield",1);
        
        await repository.AddItemAsync(item_1);
        await repository.AddItemAsync(item_2);
        
        Item item = new Item(4,"Potion",1);
        bool check = await repository.AddItemAsync(item);
        
        Assert.That(false, Is.EqualTo(check));
        Assert.That(null, Is.EqualTo(await repository.GetItemByIdAsync(4)));
    }
    
    [Test]
    public async Task 문제5번()
    {
        MockItemDataSource dataSource = new MockItemDataSource();
        IInvetoryRepository repository = new InventoryRepository(dataSource, 10, 99);
        List<Item> items = await repository.GetItemsAsync();//저장 및 얕은복사로 동기화
        
        
        Item item = new Item(4,"Potion",1);
        for (int i = 0; i < 99; i++)
        {
            await repository.AddItemAsync(item);
        }
        bool check = await repository.AddItemAsync(item);
        Assert.That(false, Is.EqualTo(check));
        Assert.That(99, Is.EqualTo(repository.GetItemByIdAsync(4).Result.count));
    }
    
}