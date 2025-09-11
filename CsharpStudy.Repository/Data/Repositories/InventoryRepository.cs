using CsharpStudy.Repository.Models;
using CsharpStudy.Repository.Data.DataSources;

namespace CsharpStudy.Repository.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IItemDataSource _dataSource; // 아이템을 실제로 저장 & 불러오는 저장소
        private readonly int _maxSlot;                // 인벤토리 슬롯의 최대 개수
        private readonly int _maxStack;               // 한 아이템이 가질 수 있는 최대 개수
    
        // 외부에서 구현체를 주입 받음
        public InventoryRepository(IItemDataSource dataSource, int maxSlot, int maxStack)
        {
            _dataSource = dataSource;  
            _maxSlot = maxSlot;       
            _maxStack = maxStack;  
        }
        
        // IItemDataSource의 LoadItemsAsync를 호출 => 현재 저장된 모든 아이템을 불러옴
        // 모든 아이템 불러옴
        public async Task<List<Item>> GetItemsAsync()
        {
            return await _dataSource.LoadItemsAsync();
        }
        
        // 모든 아이템을 불러옴 => => ID가 일치하는 아이템을 찾음
        // 없으면 null 반환
        // 특정 아이템 가져오기
        public async Task<Item?> GetItemAsync(int itemId)
        {
            var items = await _dataSource.LoadItemsAsync();
            return items.FirstOrDefault(i => i.Id == itemId);
        }
        
        // 아이템 추가하기
        public async Task<bool> AddItemAsync(Item item)
        {
            // LoadItemsAsync : 저장소에서 아이템 목록을 비동기적(타 작업을 막지 않고)으로 불러오는 메서드
            var items = await _dataSource.LoadItemsAsync();
            
            // FirstOrDefault : 아이템 목록 중 첫 번째(First) 요소를 가져옴
            // 없으면 Default => 기본값(null)
            var existing = items.FirstOrDefault(i => i.Id == item.Id);

            if (existing == null)
            {
                if (items.Count >= _maxSlot) return false; // 슬롯 꽉참
                if (item.Count > _maxStack) return false;  // 하나의 아이템이 가질 수 있는 개수 초과
 
                items.Add(item); // 새 아이템 추가
            }
            else
            {
                var newCount = existing.Count + item.Count;
                if (newCount > _maxStack) return false;     // 스택 초과 => 실패

                existing.Count = newCount;                  // 기존 아이템 수량 증가
            }

            await _dataSource.SaveAllItemAsync(items);      // 최종 저장
            return true; // 최종 저장 값에 조건이 맞으면 true 성공
        }
    }
}