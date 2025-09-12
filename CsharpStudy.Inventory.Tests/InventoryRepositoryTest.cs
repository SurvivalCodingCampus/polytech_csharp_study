using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpStudy.Inventory.Interfaces.DataSources.Mocks;
using CsharpStudy.Inventory.Models;
using NUnit.Framework;

namespace CsharpStudy.Inventory.Tests;

[TestFixture]
[TestOf(typeof(InventoryRepository))]
public class InventoryRepositoryTest
{

    [Test]
    public async Task INITIALIZE_INVENTORY_AND_LOAD()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();

        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 4, 20);

        List<Item> listOriginal = await inventory.GetAllItemsAsync();
     
        // List<Item> listToCompare = new List<Item>
        // {
        //     new Item(1, "Sword", 1),
        //     new Item(2, "Shield", 2),
        // };
        // Assert.That(listOriginal, Is.EqualTo(listToCompare));

        Assert.That(listOriginal.Exists(i => i.name == "Sword"), Is.True);
        Assert.That(listOriginal.Exists(i => i.name == "Shield"), Is.True);
    }

    [Test]
    public async Task SUCCESS_ADDING_NEW_ITEM()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();

        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 8, 88);
        await inventory.AddItemAsync(new Item(3, "Potion", 1));
        
        List<Item> listToCompare = await inventory.GetAllItemsAsync(); 
        
        Assert.That(listToCompare.Count, Is.EqualTo(3));
        Assert.That(listToCompare.Any(i => i.name == "Potion"), Is.True);
    }

    [Test]
    public async Task SUCCESS_ADDING_ITEMS_COUNT()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 4, 20);
        await inventory.AddItemAsync(new Item(1, "Sword", 1));
        
        Item itemToCompare = await inventory.GetItemByIdAsync(1);
        
        Assert.That(itemToCompare?.count, Is.EqualTo(2));
    }
    
    [Test]
    public async Task FAIL_ADDING_NEW_ITEM()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 2, 20);
        bool isSucceed = await inventory.AddItemAsync(new Item(3, "Potion", 1));
        
        Assert.That(isSucceed, Is.False);
    }

    [Test]
    public async Task FAIL_ADDING_ITEMS_COUNT()
    {
        MockItemDataSource mockItemDataSource = new MockItemDataSource();
        
        InventoryRepository inventory = new InventoryRepository(mockItemDataSource, 4, 99);
        await inventory.AddItemAsync(new Item(3, "Potion", 99));
        
        bool isSucceed = await inventory.AddItemAsync(new Item(3, "Potion", 1));
        
        Assert.That(isSucceed, Is.False);
    }
}