using System;
using CsharpStudy.Game.Characters;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Characters;

[TestFixture]
[TestOf(typeof(Cleric))]
public class ClericTest
{

    [Test]
    public void Cleric의_Hp는__0보다_작을_수_없다()
    {
        Cleric cleric = new Cleric("홍");
        //cleric.Hp = -1;
        Assert.Throws<ArgumentException>(() => cleric.Hp = -1);
    }
}