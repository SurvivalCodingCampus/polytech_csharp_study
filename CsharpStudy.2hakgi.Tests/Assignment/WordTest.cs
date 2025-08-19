using CsharpStudy._2hakgi.Assignment;
using NUnit.Framework;
using System;

namespace CsharpStudy._2hakgi.Tests.Assignment
{
    [TestFixture]
    [TestOf(typeof(Word))]
    public class WordTest
    {
        [Test]
        public void IsVowel_Test()
        {
            Word w = new Word("Hello");

            // 모음 테스트
            Assert.That(w.IsVowel(1), Is.True);   // 'e' -> 모음 
            Assert.That(w.IsVowel(4), Is.True);   // 'o' -> 모음

            // 자음 테스트
            Assert.That(w.IsVowel(0), Is.False);  // 'H' -> 자음
            Assert.That(w.IsVowel(2), Is.False);  // 'l' -> 자음
        }

        [Test]
        public void IsVowel_Index_Range_Test()
        {
            Word w = new Word("Test");

            // 인덱스 범위를 벗어난 경우 예외
            Assert.Throws<ArgumentOutOfRangeException>(() => w.IsVowel(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => w.IsVowel(4));

            // 범위 내 정상 호출
            Assert.That(w.IsVowel(0), Is.False); // 'T' -> 자음
            Assert.That(w.IsVowel(1), Is.True);  // 'e' -> 모음
        }

        [Test]
        public void IsVowel_Alphabet_Test()
        {
            Word w = new Word("H@@@o!");

            // 알파벳이 아닌 경우 예외
            Assert.Throws<FormatException>(() => w.IsVowel(1)); // '@'
            Assert.Throws<FormatException>(() => w.IsVowel(5)); // '!'

            // 알파벳 범위 내 정상 호출
            Assert.That(w.IsVowel(0), Is.False);    // 'H' -> 자음
            Assert.That(w.IsVowel(4), Is.True);     // 'o' -> 모음
        }

        [Test]
        public void IsConsonant_Test()
        {
            Word w = new Word("Hello");

            // 자음 확인
            Assert.That(w.IsConsonant(0), Is.True);   // 'H' -> 자음
            Assert.That(w.IsConsonant(2), Is.True);   // 'l' -> 자음

            // 모음은 false
            Assert.That(w.IsConsonant(1), Is.False);  // 'e' -> 모음
            Assert.That(w.IsConsonant(4), Is.False);  // 'o' -> 모음
        }
    }
}
