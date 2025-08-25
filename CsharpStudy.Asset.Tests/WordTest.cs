using System;
using CsharpStudy.Asset;
using NUnit.Framework;

namespace CsharpStudy.Asset.Tests;

[TestFixture]
public class WordTest
{

    [Test]
    public void 문자열의_각_자리수가_모음인지_자음인지_확인하기()
    {
        Word word = new Word("Program");
        
        Assert.That(word.IsConsonant(0), Is.True);  // 'P'
        Assert.That(word.IsVowel(0), Is.False);  // 'P'
        Assert.That(word.IsConsonant(1), Is.True);  // 'r'
        Assert.That(word.IsVowel(1), Is.False);  // 'r'
        Assert.That(word.IsConsonant(2), Is.False);  // 'o'
        Assert.That(word.IsVowel(2), Is.True);  // 'o'
        Assert.That(word.IsConsonant(3), Is.True);  // 'g'
        Assert.That(word.IsVowel(3), Is.False);  // 'g'
        Assert.That(word.IsConsonant(4), Is.True);  // 'r'
        Assert.That(word.IsVowel(4), Is.False);  // 'r'
        Assert.That(word.IsConsonant(5), Is.False);  // 'a'
        Assert.That(word.IsVowel(5), Is.True);  // 'a'
        Assert.That(word.IsConsonant(6), Is.True);  // 'm'
        Assert.That(word.IsVowel(6), Is.False);  // 'm'

    }
}