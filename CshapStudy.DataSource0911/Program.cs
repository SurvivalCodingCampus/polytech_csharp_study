using CshapStudy.DataSource0911.Data;
using CshapStudy.DataSource0911.Models;


namespace CshapStudy.DataSource0911;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("1번-------------------");
        // 테스트 케이스 1. 인벤토리 초기화 및 로드
        // Given: MockItemDataSource에 "Sword"와 "Shield"가 준비되어 있습니다.
        //     When: InventoryRepository를 초기화하고 아이템 목록을 로드합니다.
        //     Then: 인벤토리에는 "Sword"와 "Shield" 두 아이템이 포함되어야 합니다.
        IItemDataSource dataSource = new MockItemDataSource();

        List<Item> items =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 1)
        ];
        await dataSource.SaveAllItemsAsync(items);


        InventoryRepository inventory = new InventoryRepository(dataSource, 3, 3);
        
        List<Item> allItems = await inventory.GetItemsAsync();
        allItems.ForEach(item => Console.WriteLine(item.Name));
        Console.WriteLine("2번-------------------");


        // 테스트 케이스 2. 새로운 아이템 추가 (성공)
        // Given: 인벤토리에 "Potion" 아이템이 없습니다. maxSlot에는 여유가 있습니다.
        //     When: "Potion" 아이템을 인벤토리에 추가합니다.
        //     Then: 인벤토리의 총 아이템 종류 수가 3개로 늘어나고, "Potion"이 목록에 있어야 합니다.

        Item AddPotion = new Item(3, "Potion", 4);
        await inventory.AddItemAsync(AddPotion);
        List<Item> allPotions = await inventory.GetItemsAsync();
        allItems.ForEach(item => Console.WriteLine(item.Name));
        Console.WriteLine("3번-------------------");


        // 테스트 케이스 3. 기존 아이템 개수 증가 (성공)
        // Given: "Sword" 아이템이 인벤토리에 1개 있습니다. "Sword"의 maxStack은 20입니다.
        //     When: "Sword" 아이템을 다시 1개 추가합니다.
        //     Then: "Sword" 아이템의 개수가 2개로 증가해야 합니다.

        Item AddSword = new Item(4, "Sword", 1);
        await inventory.AddItemAsync(AddSword);
        List<Item> allSwords = await inventory.GetItemsAsync();
        allSwords.ForEach(item => Console.WriteLine(item.Name));
        Console.WriteLine("4번-------------------");

        // 테스트 케이스 4. 새로운 아이템 추가 (실패 - maxSlot 초과)
        // Given: 인벤토리의 maxSlot이 2이며, 현재 "Sword"와 "Shield" 두 아이템이 있습니다.
        //     When: "Potion" 아이템을 인벤토리에 추가하려 시도합니다.
        //     Then: AddItemAsync 메서드는 false를 반환해야 하며, "Potion"은 인벤토리 목록에 추가되지 않아야 합니다

        inventory = new InventoryRepository(dataSource, 2, 3);
        Item nondPotion = new Item(5, "Potion", 2);
        bool addItemResult = await inventory.AddItemAsync(nondPotion);
        List<Item> nonPotions = await inventory.GetItemsAsync();
        allItems.ForEach(item => Console.WriteLine(item.Name));
        Console.WriteLine("5번-------------------");

        // 테스트 케이스 5. 아이템 개수 증가 (실패 - maxStack 초과)
        // Given: "Potion" 아이템이 인벤토리에 99개 있습니다. maxStack은 99입니다.
        //     When: "Potion" 아이템을 다시 1개 추가하려 시도합니다.
        //     Then: AddItemAsync 메서드는 false를 반환해야 하며, "Potion"의 개수는 여전히 99개여야 합니다.
        inventory = new InventoryRepository(dataSource, 2, 99);
        Item nondpotion = new Item(6, "Potion", 1);
        bool addItemresult = await inventory.AddItemAsync(nondpotion);
        List<Item> nonpotions = await inventory.GetItemsAsync();
        allItems.ForEach(item => Console.WriteLine(item.Name));
    }
}