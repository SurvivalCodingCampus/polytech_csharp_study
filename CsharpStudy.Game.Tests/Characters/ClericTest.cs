using System;
using CsharpStudy.Game.Characters;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Characters;

[TestFixture]
{

    [Test]
    public void Cleric의_Hp는_0보다_작을_수_없다()
    {
        Cleric cleric = new Cleric("홍길동");
        // cleric.Hp = -1;
        Assert.Throws<ArgumentException>(() => cleric.Hp = -1);
    }
}