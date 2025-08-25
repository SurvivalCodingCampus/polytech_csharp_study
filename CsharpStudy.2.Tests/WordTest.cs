using CsharpStudy._2;
using NUnit.Framework;

namespace CsharpStudy._2.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{

    [Test]
    public void IsVowel_모음찾기()
    {
        Word w = new Word("apple");
        Assert.That(w.IsVowel(0)); // 'a'
        Assert.That(w.IsVowel(4)); // 'e'
    }
    
    
    [Test]
    public void IsVowel_자음일_경우_flase()
    {
        Word w = new Word("test");
        Assert.That(w.IsVowel(0), Is.False); // 't'
        Assert.That(w.IsVowel(1), Is.True); // 'e'
    }
    
    [Test]
    public void IsConsonant_자음찾기()
    {
        Word w = new Word("apple");
        Assert.That(w.IsConsonant(1)); // 'p'
        Assert.That(w.IsConsonant(3)); // 'l'
    }
    
    [Test]
    public void IsConsonant_모음일_경우_flase()
    {
        Word w = new Word("test");
        Assert.That(w.IsConsonant(1), Is.False); // 'e'
        Assert.That(w.IsConsonant(2), Is.True); // 's'
    }
}