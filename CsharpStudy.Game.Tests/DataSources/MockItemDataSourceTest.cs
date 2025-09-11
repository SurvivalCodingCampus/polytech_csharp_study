using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asynchronous;
using Asynchronous.Data.Repositorues;
using Asynchronous.DataSources;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.DataSources;

[TestFixture]
[TestOf(typeof(MockItemDataSource))]
public class MockItemDataSourceTest
{

    [Test]
    public async Task 인벤토리_초기화_및_로드()
    {
        
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        IInvetoryRepository invetoryRepository = new InventoryRepository(mockItemDataSource, 2, 4);//비동기 초기화 및 로드
        List<Item> loadedItems = await invetoryRepository.GetAllItemsAsync();

        Assert.That(loadedItems.Any(items => items.Name == "Sword"), Is.True);
        Assert.That(loadedItems.Any(items => items.Name == "Shield"), Is.True);
        
    }
    [Test]
    public async Task 새로운_아이템_추가_성공()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        IInvetoryRepository invetoryRepository = new InventoryRepository(mockItemDataSource, 10, 4);//비동기 초기화 및 로드
        List<Item> loadedItems = await invetoryRepository.GetAllItemsAsync();
        
        Item item =  new Item(0,"Posion", 1);
        loadedItems.Add(item);
        
        Assert.That(loadedItems.Any(items => items.Name == "Posion"), Is.True);
        item.Count = 3;
        Assert.That(loadedItems.Any(items => items.Count == 3), Is.True);

    }
    [Test]
    public async Task 기존_아이템_개수_증가_성공()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        IInvetoryRepository invetoryRepository = new InventoryRepository(mockItemDataSource, 10, 30);//비동기 초기화 및 로드
        List<Item> loadedItems = await invetoryRepository.GetAllItemsAsync();
        Item item =  new Item(0,"Sword", 1);
        loadedItems.Add(item);
        item.Count = 2;
        Assert.That(loadedItems.Any(items => items.Count == 2), Is.True);
        
    }
    [Test]
    public async Task 새로운_아이템_추가_실패_maxSlot_초과()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        IInvetoryRepository invetoryRepository = new InventoryRepository(mockItemDataSource, 2, 99);//비동기 초기화 및 로드
        List<Item> loadedItems = await invetoryRepository.GetAllItemsAsync();
        Item item =  new Item(0,"Posion", 1);
        loadedItems.Add(item);
        item.Count = 2;
        Assert.That(loadedItems.Any(items => items.Count == 2), Is.True);
        
        
    }
    [Test]
    public async Task 아이템_개수_증가_실패_maxStack_초과()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        IInvetoryRepository invetoryRepository = new InventoryRepository(mockItemDataSource, 99, 99);//비동기 초기화 및 로드
        List<Item> loadedItems = await invetoryRepository.GetAllItemsAsync();
        Item item =  new Item(0,"Posion", 99);
        Item item2 =  new Item(0,"Posion", 1);
        loadedItems.Add(item);
        loadedItems.Add(item2);
        Assert.That(loadedItems.Any(items => items.Count == 99), Is.True);

        
    }
}