using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpStudy._0911;
using NUnit.Framework;

namespace CsharpStudy._0911.Testss.Data.Repositories
{
    [TestFixture]
    public class InventoryRepositoryTest
    {
        [Test]
        public async Task test1()
        {
            MockItemDataSource _mockItemDataSource = new MockItemDataSource();
            InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 100, 100);

            var FindItem = await _inventory.GetItemsAsync();
            
            Assert.IsTrue(FindItem.Any(items => items.Name=="Sword"));
            Assert.IsTrue(FindItem.Any(items => items.Name=="Shield"));
        }

        [Test]
        public async Task test2()
        {
            MockItemDataSource _mockItemDataSource = new MockItemDataSource();
            InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 100, 100);
            Item itempotion = new Item(300, "Potion", 3);
            
            var FindItem = await _inventory.GetItemsAsync();
            Assert.IsTrue(FindItem.Any(items => items.Name=="Potion"));
        }

        [Test]
        public async Task test3()
        {
            MockItemDataSource _mockItemDataSource = new MockItemDataSource();
            InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 100, 20);
            var findItem = await _inventory.GetItemsAsync();
            
            Item swordItem = new Item(300, "Sword", 3);
            Assert.IsTrue(findItem.Any(items => items.Count==3));
        }

        [Test]
        public async Task test4()
        {
            MockItemDataSource _mockItemDataSource = new MockItemDataSource();
            InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 100, 20);
            var findItem = await _inventory.GetItemsAsync();
            
            Item itempotion = new Item(300, "Potion", 1);
            
            bool result = await _inventory.AddItemAsync(itempotion);
            Assert.IsTrue(result);
        }

        [Test]
        public async Task test5()
        {
            MockItemDataSource _mockItemDataSource = new MockItemDataSource();
            InventoryRepository _inventory = new InventoryRepository(_mockItemDataSource, 100, 99);
            var findItem = await _inventory.GetItemsAsync();
            
            Item itempotion = new Item(300, "Potion", 1);
            findItem.Add(itempotion);
            
            bool result = await _inventory.AddItemAsync(itempotion);
            Assert.IsFalse(result);
            
            Assert.IsTrue(findItem.Any(items => items.Count == 99));
            
        }
    }
}