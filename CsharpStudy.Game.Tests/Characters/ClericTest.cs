using System;
using CsharpStudy.Game.Characters;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Characters;

[TestFixture]
[TestOf(typeof(Cleric))]
public class ClericTest
{

    [Test] public void Cleric_Hp_cannot_be_less_than_0()
    {
        Cleric cleric = new Cleric("홍길동");
        // cleric.Hp = -1;
        Assert.Throws<ArgumentException>(() => cleric.Hp = -1);
    }
}