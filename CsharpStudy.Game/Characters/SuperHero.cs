using CsharpStudy.Game.Interfaces;

namespace CsharpStudy.Game.Characters;

public class SuperHero : Character, IAttackable, IMoveable
{
    // interface 메서드 구현 시 override 키워드 불필요
    // 추상 클래스의 메서드 구현 시 override 키워드 필요
    public override void Run()
    {
        
    }

    public void Move()
    {
        
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }
}