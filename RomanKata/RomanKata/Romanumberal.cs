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
        private int previousNumeral;
        public int Total { get; private set; }

        public NumeralTotaler Add(char numeral)
        {
            var currentNumeral = GetValueOf(numeral);
            Total += currentNumeral;
            SubtractPreviousNumeralIfSmallerThanCurrentNumeral(currentNumeral);
            previousNumeral = currentNumeral;
            return this;
        }

        private void SubtractPreviousNumeralIfSmallerThanCurrentNumeral(int currentNumeral)
        {
            if (previousNumeral < currentNumeral)
                Total = Total - previousNumeral - previousNumeral;
        }

        private static int GetValueOf(char character)
        {
            switch (character)
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
