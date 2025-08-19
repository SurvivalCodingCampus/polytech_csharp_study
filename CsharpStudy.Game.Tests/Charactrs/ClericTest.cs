using System;
using CsharpStudy.Game.Charactrs;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Charactrs;

[TestFixture]
[TestOf(typeof(Cleric))]
public class ClericTest
{

    [Test]
    public void Cleric의_HP는_0보다_작을_수_없다()
    {
        Cleric cleric = new Cleric("홍길동");
        //cleric.HP = -1;
        Assert.Throws<ArgumentException>(() => cleric.HP = 1);
    }
}