using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpStudy.Repository.DataSources;
using CsharpStudy.Repository.Models;
using CsharpStudy.Repository.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Repository.Tests.Repositories;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{
    private IItemDataSource _dataSource = new MockItemDataSource();
    private IInventoryRepository _repository;

    [SetUp]
    public void SetUp()
    {
        _dataSource = new MockItemDataSource();
    }
    
    [Test]
    public async Task 인벤토리_초기화_및_로드()
    {
        _repository = new InventoryRepository(_dataSource, 10, 10);
        await _repository.AddItemAsync(new Item(1, "Sword", 10));
        await _repository.AddItemAsync(new Item(2, "Shield", 10));

        List<Item> items = await _repository.GetItemsAsync();
        Assert.That(items.Any(e => e.Name == "Sword"));
        Assert.That(items.Any(e => e.Name == "Shield"));
    }

    [Test]
    public async Task 새로운_아이템_추가_성공()
    {
        // given
        _repository = new InventoryRepository(_dataSource, 10, 10);
        await _repository.AddItemAsync(new Item(1, "Sword", 10));
        await _repository.AddItemAsync(new Item(2, "Shield", 10));
        
        // when
        await _repository.AddItemAsync(new Item(3, "Potion", 10));
        
        // then
        List<Item> items = await _repository.GetItemsAsync();
        Assert.That(items.Count, Is.EqualTo(3));
        Assert.That(items.Any(e => e.Name == "Potion"));
        
    }

    [Test]
    public async Task 기존_아이템_개수_증가_성공()
    {
        _repository = new InventoryRepository(_dataSource, 20, 10);
        await _repository.AddItemAsync(new Item(1, "Sword", 1));
        
        await _repository.AddItemAsync(new Item(1, "Sword", 1));
        
        List<Item> items = await _repository.GetItemsAsync();

        Item sword = await _repository.GetItemByIdAsync(1);
        Assert.That(sword!.Name == "Sword");
        Assert.That(sword!.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task 새로운_아이템_추가_실패_maxSlot_초과()
    {
        // given
        _repository = new InventoryRepository(_dataSource, 2, 10);
        await _repository.AddItemAsync(new Item(1, "Sword", 10));
        await _repository.AddItemAsync(new Item(2, "Shield", 10));
        
        bool result = await _repository.AddItemAsync(new Item(3, "Potion", 10));
        
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task 아이템_개수_증가_실패_maxStack_초과()
    {
        _repository = new InventoryRepository(_dataSource, 2, 99);
        await _repository.AddItemAsync(new Item(3, "Potion", 99));
        
        
        bool result = await _repository.AddItemAsync(new Item(3, "Potion", 1));
        Assert.That(result, Is.False);

        Item potion = await _repository.GetItemByIdAsync(3);
        Assert.That(potion!.Count, Is.EqualTo(99));
    }
}