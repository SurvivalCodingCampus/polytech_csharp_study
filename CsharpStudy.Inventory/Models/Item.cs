namespace CsharpStudy.Inventory.Models;

public class Item
{
    public int id { get; set; }
    public string name { get; set; }
    public int count { get; set; }

    public Item()
    {
        
    }

    public Item(int id, string name) : this(id, name, 1)
    {
        
    }

    public Item(int id, string name, int count)
    {
        this.id = id;
        this.name = name;
        this.count = count;
    }

    // id를 기준으로 아이템을 판단할 거라면 동등성 비교 기준을 수정하는 것도 좋다.
    // Equals() 재정의시 GetHashCode() 도 재정의하는게 좋다고 한다..
    
    // // `Item` 객체의 동등성 비교를 위한 Equals 재정의
    // public override bool Equals(object obj)
    // {
    //     // 1. 참조 동등성 검사 (두 객체가 동일한 인스턴스인지)
    //     if (ReferenceEquals(this, obj))
    //     {
    //         return true;
    //     }
    //
    //     // 2. null 검사 및 타입 검사
    //     if (obj is null || obj.GetType() != this.GetType())
    //     {
    //         return false;
    //     }
    //
    //     // 3. 필드 값 비교
    //     var otherItem = (Item)obj;
    //     return this.id == otherItem.id && this.name == otherItem.name;
    // }
    
    // Equals 재정의 시 GetHashCode도 재정의해야 함
    // public override int GetHashCode()
    // {
    //     // `id`와 `name`을 기반으로 해시 코드 생성
    //     // null인 경우를 대비하여 name에 대한 null 검사를 포함
    //     return HashCode.Combine(id, name);
    // }
}