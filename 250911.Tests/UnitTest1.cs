using _250911.Data.DataSources;
using _250911.Data.Repositories;
using System.Linq;
using _250911.Models;

namespace _250911.Tests;

public class Tests
{
         [Test]
         public async Task Test1()
         {
             MockItemDataSource _mockItemDataSource = new MockItemDataSource();
             
             InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 10,10);
             
             var checkItem = await _inventory.GetItemsAsync();
             
             Assert.IsTrue(checkItem.Any(items=> items.Name=="Sword"));
             Assert.IsTrue(checkItem.Any(items=> items.Name=="Shield"));
             
             
         }


         [Test]
         public async Task Test2()
         {
             MockItemDataSource _mockItemDataSource = new MockItemDataSource();
             InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 10,10);
             
             Item potionItem =   new Item(30, "Potion", 1);
             
             var checkItem = await _inventory.GetItemsAsync();
             checkItem.Add(potionItem);
             
             Assert.IsTrue(checkItem.Any(items=> items.Name=="Potion"));
             
         }

         [Test]
         public async Task Test3()
         {
             MockItemDataSource _mockItemDataSource = new MockItemDataSource();
             InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 10,20);
             var checkItem = await _inventory.GetItemsAsync();
             
            Item swordItem = new Item(10, "Sword", 1);
            checkItem.Add(swordItem);
             
             Assert.IsTrue(checkItem.Any(item =>item.Count==2));
             
         }

         [Test]
         public async Task Test4()
         {
             MockItemDataSource _mockItemDataSource = new MockItemDataSource();
             InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 2,20);
             var checkItem = await _inventory.GetItemsAsync();
             
             Item potionItem = new Item(30, "Potion", 1);
             checkItem.Add(potionItem);
             
             bool result = await _inventory.AddItemAsync(potionItem);
             
             Assert.IsFalse(result);
             
            
         }

         [Test]
         public async Task Test5()
         {
             MockItemDataSource _mockItemDataSource = new MockItemDataSource();
             InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 2,99);
             var checkItem = await _inventory.GetItemsAsync();
             
             Item potionItem = new Item(30, "Potion", 99);
             checkItem.Add(potionItem);
             
             Item potionItem2 = new Item(30, "Potion", 1);
             checkItem.Add(potionItem2);
             
             bool result = await _inventory.AddItemAsync(potionItem2);
             Assert.IsFalse(result);
             
             Assert.IsTrue(checkItem.Any(item =>item.Count==99));
         }
}