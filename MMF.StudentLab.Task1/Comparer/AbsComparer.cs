using System; 
using WorkToArray;

namespace Comparer
{
    public class AbsComparer : IComparer
    {
        public int Compare(int left, int right)
            => Math.Abs(left) - Math.Abs(right); 
    }
}