using CsharpStudy.Game.Interfaces;

namespace CsharpStudy.Game.Characters;

public class SuperHero : Character, IAttackable, IMoveable
{
    public override void Run()
    {
        throw new NotImplementedException();         // 'Not Implemented' == '구현하지 않았음'
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }

    public void Move()
    {
        throw new NotImplementedException();
    }
}