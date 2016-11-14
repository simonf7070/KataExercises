namespace RomanKata
{
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