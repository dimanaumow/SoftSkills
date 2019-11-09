using System; 
using WorkToArray;

namespace Comparer
{
    public class CountSymbolCompare : IComparer
    {
        private int P { get; set; }

        public CountSymbolCompare(int p)
        {
            if (p > 16 || p < 2)
            {
                throw new ArgumentException("Invalid base number system!");
            }
            this.P = p; 
        }

        public int Compare(int left, int right)
            => (CountSymbols(Math.Abs(left), P) - CountSymbols(Math.Abs(right), P));
        public int CountSymbols(int number, int p)
        {
            int count = 0;
            while (number != 0)
            {
                count++;
                number /= p;
            }
            return count;
        }
    }
}