using CsharpStudy.Game.Interface;

namespace CsharpStudy.Game.Characters;

public class Hero : SuperHero, IAttackable, IMoveable
{
    public void Attack()
    {
        throw new NotImplementedException();
    }

    public void Move()
    {
        throw new NotImplementedException();
    }

    public override void Run()
    {
        throw new NotImplementedException();
    }
}