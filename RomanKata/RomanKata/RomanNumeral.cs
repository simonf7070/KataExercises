using System.Linq;
using System.Text;

namespace RomanKata
{
    public static class RomanNumeral
    {
        public static string ConvertToRomanNumeral(int number)
        {
            var result = new StringBuilder();
            var remainder = number;
            while (remainder > 0)
            {
                var divider = GetLargestDivider(remainder);
                result.Append(Translate(divider));
                remainder = remainder - divider;
            }
            return result.ToString();
        }

        private static int GetLargestDivider(int value)
        {
            if (CanDivideValueBy(value, 1000)) return 1000;
            if (CanDivideValueBy(value, 500)) return 500;
            if (CanDivideValueBy(value, 100)) return 100;
            if (CanDivideValueBy(value, 50)) return 50;
            if (CanDivideValueBy(value, 10)) return 10;
            if (CanDivideValueBy(value, 5)) return 5;

            return 1;
        }

        private static bool CanDivideValueBy(int value, int divider)
        {
            return (value / divider) >= 1;
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
}
