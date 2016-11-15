using System.Linq;
using System.Text;

namespace RomanKata
{
    public static class RomanNumeral
    {
        public static int ConvertFromRomanNumeral(string romanNumeral)
        {
            var seed = new NumeralTotaler();
            return romanNumeral
                .Aggregate(seed, (numeralTotaler, numeral) => numeralTotaler.Add(numeral))
                .Total;
        }

        /*
        Decimal number to roman numerals conversion

        For decimal number x:
        
        1. From the following table, find the highest decimal value v that is less than or equal to the decimal number x
        and its corresponding roman numeral n:
 
            Decimal value(v)   Roman numeral(n)
            1	               I
            4	               IV
            5	               V
            9	               IX
            10	               X
            40	               XL
            50	               L
            90	               XC
            100	               C
            400	               CD
            500	               D
            900	               CM
            1000	           M

        2. Write the roman numeral n that you found and subtract its value v from x:
            x = x - v
        3. Repeat stages 1 and 2 until you get zero result of x.
        */

        public static string ConvertToRomanNumeral(int number)
        {
            var numberString = number.ToString();
            var result = new StringBuilder();

            for (int i = 0; i < numberString.Length; i++)
            {
                var count = numberString.Length - 1 - i;
                var s = numberString[i] + new string('0', count);
                var unit = int.Parse(s);
                
                while (unit > 0)
                {
                    var divider = GetLargestDivider(unit);

                    int largerDivider;
                    int largerSubtracter;
                    if (UseNextLargestDividerAndSubtraction(unit, out largerDivider, out largerSubtracter))
                    {
                        result.Append(Translate(largerSubtracter));
                        result.Append(Translate(largerDivider));
                        unit = unit - largerDivider - largerSubtracter;
                    }
                    else
                    {
                        result.Append(Translate(divider));
                        unit = unit - divider;
                    }
                }
            }
            return result.ToString();
        }

        private static bool UseNextLargestDividerAndSubtraction(int remainder, out int largerDivider, out int largerSubtracter)
        {
            largerDivider = 0;
            largerSubtracter = 0;

            if (remainder == 4)
            {
                largerDivider = 5;
                largerSubtracter = 1;
                return true;
            }
            if (remainder == 9)
            {
                largerDivider = 10;
                largerSubtracter = 1;
                return true;
            }
            return false;
        }

        private static int GetLargestDivider(int value)
        {
            if (value.IsDivisableBy(1000)) return 1000;
            if (value.IsDivisableBy(500)) return 500;
            if (value.IsDivisableBy(100)) return 100;
            if (value.IsDivisableBy(50)) return 50;
            if (value.IsDivisableBy(10)) return 10;
            if (value.IsDivisableBy(5)) return 5;
            return 1;
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

        private static bool IsDivisableBy(this int value, int divider)
        {
            return value / divider >= 1;
        }
    }
}
