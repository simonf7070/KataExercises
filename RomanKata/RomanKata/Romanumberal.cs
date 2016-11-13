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
            var seed = new Accumulator();
            return romanNumeral
                .Reverse()
                .Aggregate(seed, (accumulator, character) => accumulator.Add(Translate(character)))
                .Total;
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
        private int previousValue;
        public int Total { get; private set; } 

        public Accumulator Add(int currentValue)
        {
            Total += GetValueWithOperator(previousValue, currentValue);
            previousValue = currentValue;
            return this;
        }

        private int GetValueWithOperator(int previous, int current)
        {
            return previous > current ? -current : current;
        }
    }
}
