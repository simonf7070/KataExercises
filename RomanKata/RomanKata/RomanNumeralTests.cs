using NUnit.Framework;

namespace RomanKata
{
    [TestFixture]
    public class RomanNumeralTests
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
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("MCMLXXXIV", 1984)]
        public void ConvertRomanNumeral(string seq, int expected)
        {
            Assert.That(RomanNumeral.ConvertFromRomanNumeral(seq), Is.EqualTo(expected));
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(19, "XIX")]
        //[TestCase(40, "XL")]
        //[TestCase(49, "XLIX")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        public void ConvertToRomanNumeralSequence(int number, string expected)
        {
            Assert.That(RomanNumeral.ConvertToRomanNumeral(number), Is.EqualTo(expected));
        }
    }
}