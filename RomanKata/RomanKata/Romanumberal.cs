using System.Linq;

namespace RomanKata
{
    public static class Romanumberal
    {
        public static string ConvertToRomanNumeral(int number)
        {
            return "I";
        }

        public static int ConvertFromRomanNumeral(string romanNumeral)
        {
            var seed = new NumeralTotaler();
            return romanNumeral
                .Aggregate(seed, (numeralTotaler, numeral) => numeralTotaler.Add(numeral))
                .Total;
        }

        private static char Translate(int number)
        {
            switch (number)
            {
                case 1:
                    return 'I';
                case 5:
                    return 'V';
                case 10:
                    return 'X';
                case 50:
                    return 'L';
                case 100:
                    return 'C';
                case 500:
                    return 'D';
                case 1000:
                    return 'M';
                default:
                    return ' ';
            }
        }
    }

    public class NumeralTotaler
    {
        private int previous;
        public int Total { get; private set; }

        public NumeralTotaler Add(char numeral)
        {
            var current = GetValueOf(numeral);
            Total += current;
            ReversePreviousAdditionThenSubtractPreviousIfPreviousSmallerThanCurrent(current);
            previous = current;
            return this;
        }

        private void ReversePreviousAdditionThenSubtractPreviousIfPreviousSmallerThanCurrent(int current)
        {
            if (previous < current)
                Total = Total - previous - previous;
        }

        private static int GetValueOf(char numeral)
        {
            switch (numeral)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
