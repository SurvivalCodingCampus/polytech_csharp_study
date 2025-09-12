namespace CsharpStudy.DataSource1;

public class MockItemDataSource : IItemDataSource
{
    private List<Item> _items;

    public MockItemDataSource(List<Item> initialItems)
    {
        _items = initialItems;
    }

    public Task<List<Item>> LoadAllItemsAsync()
    {
        // 깊은 복사로 외부 수정 방지
        var clone=_items.Select(i=>new Item(i.id, i.name, i.count)).ToList();
        // 이미 계산 된 값이 있을 때 await를 쓰지않고 FromResult 사용
        return Task.FromResult(clone);
    }

    public Task SaveAllItemAsync(List<Item> items)
    {
        _items=items.Select(i=>new Item(i.id, i.name, i.count)).ToList();
        // Task.CompletedTask : 아무 일도 안 하고 바로 끝나는 Task
        return Task.CompletedTask;
    }

    // 테스트용: 현재 아이템 상태 가져오기
    public List<Item> GetCurrentItems() => _items;
}