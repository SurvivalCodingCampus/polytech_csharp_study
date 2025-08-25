using System;
using CsharpStudy.Game.Characters;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Characters;

[TestFixture]
public class ClericTest
{

    [Test]
    public void Cleric의_Hp는_0보다_작을_수_없다()
    {
        Cleric cleric = new Cleric("홍길동");  // MaxHp == 50, MaxMp == 10
        
        // Check whether the assertion catches 'ArgumentException' successfully.
        // == whether ArgumentException is thrown as intended.
        Assert.Throws<ArgumentException>(() => cleric.Hp = -1);
    }
}