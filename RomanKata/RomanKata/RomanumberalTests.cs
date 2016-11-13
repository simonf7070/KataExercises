using NUnit.Framework;

namespace RomanKata
{
    [TestFixture]
    public class RomanumberalTests
    {
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VII", 7)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("MCMLXXXIV", 1984)]
        public void ConvertRomanNumeral(string seq, int expected)
        {
            Assert.That(Romanumberal.ConvertFromRomanNumeral(seq), Is.EqualTo(expected));
        }

        [TestCase(1, "I")]
        public void ConvertToRomanNumeralSequence(int number, string expected)
        {
            Assert.That(Romanumberal.ConvertToRomanNumeral(number), Is.EqualTo(expected));
        }
    }
}