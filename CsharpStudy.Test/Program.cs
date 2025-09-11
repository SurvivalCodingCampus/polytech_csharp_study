using System.Collections.Generic;
using System.Threading.Tasks;
using CsharpStudy._0911;
using NUnit.Framework;

namespace CsharpStudy.Tests
{
    [TestFixture] 
    public class InventoryRepositoryTests
    {
        [Test]
        public async Task Case1()
        {
            // Arrange
            var seed = new List<Item>
            {
                new Item(1, "Sword", 1),
                new Item(2, "Shield", 1)
            };
            var mock = new MockItemDataSource(seed);
            var repo  = new InventoryRepository(mock, maxSlot: 10, maxStack: 99);

            // Act
            var items = await repo.GetItemsAsync(); 

            // Assert
            Assert.That(items.Count, Is.EqualTo(2));
            Assert.That(mock.LoadAllItemsAsync(), Is.EqualTo(1));
            Assert.That(mock.SaveAllItemsAsync(), Is.EqualTo(0));
        }
    }
}