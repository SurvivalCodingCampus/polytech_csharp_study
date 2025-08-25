using CsharpStudy._2hakgi;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{
    [Test]
    public void 모음_자음_메서드_소문자_테스트()
    {
        // Arrange (준비)
        var word = new Word("apple");

        // Act (실행) & Assert (검증)
        Assert.That(word.IsVowel(0).Equals(true)); // 'a'
        Assert.That(word.IsConsonant(0).Equals(false)); // 'a'
    }
    [Test]
    public void 모음_자음_메서드_대문자_테스트()
    {
        // Arrange (준비)
        var word = new Word("APPLE");

        // Act (실행) & Assert (검증)
        Assert.That(word.IsVowel(0).Equals(true)); // 'a'
        Assert.That(word.IsConsonant(0).Equals(false)); // 'a'
    }

}