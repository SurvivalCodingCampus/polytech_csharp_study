using CsharpStudy.Game.Interfaces;

namespace CsharpStudy.Game.Characters;

public class Hero : SuperHero, IAttackable
{
    public void Attack()
    {
        throw new NotImplementedException();        // 'Not Implemented' == '구현하지 않았음'
    }
}