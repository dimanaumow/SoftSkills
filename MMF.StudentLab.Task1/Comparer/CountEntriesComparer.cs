using System; 
using WorkToArray;

namespace Comparer
{
    public class CountEntriesComparer : IComparer
    {
        private int P { get; set; }
        private char C { get; set; }
        private string alpfabet = "0123456789ABCDEF";
        public CountEntriesComparer(int p, char c)
        {
            if(p > 16 || p < 2)
            {
                throw new ArgumentException("Invalid base number system!"); 
            }
            if(p < alpfabet.IndexOf(c))
            {
                throw new ArgumentException("Invalid symbol c!"); 
            }

            this.P = p;
            this.C = c;
        }
        public int Compare(int left, int right)
            => (CountEntries(Math.Abs(left), P, C) - CountEntries(Math.Abs(right), P, C));

        public int CountEntries(int number, int p, char c)
        {
            int count = 0;
            int element = alpfabet.IndexOf(c);

            while (number != 0)
            {
                if (number % p == element)
                {
                    count++;
                }
                number /= p;
            }
            return count;
        }
    }
}