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
            var seed = new Accumulator { PreviousValue = 0, Total = 0 };
            return romanNumeral
                .Reverse()
                .Aggregate(seed, (accumulator, character) => Add(Translate(character), accumulator))
                .Total;
        }

        private static Accumulator Add(int currentValue, Accumulator accumulator)
        {
            return new Accumulator
            {
                PreviousValue = currentValue,
                Total = accumulator.Total + GetValueWithOperator(accumulator.PreviousValue, currentValue)
            };
        }

        private static int GetValueWithOperator(int previous, int current)
        {
            return previous > current ? -current : current;
        }

        private static int Translate(char character)
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

    public class Accumulator
    {
        public int PreviousValue { get; set; }
        public int Total { get; set; }
    }
}
