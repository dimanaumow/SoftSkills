using System;
using NUnit.Framework;
using Comparer;

namespace Comparer_test
{
    [TestFixture]
    public class Comparer_tests
    {
        [TestCase(5, 3, ExpectedResult = 2)]
        [TestCase(5, -3, ExpectedResult = 2)]
        [TestCase(-4, -3, ExpectedResult = 1)]
        [TestCase(5, 5, ExpectedResult = 0)]
        public int AbsComparer_test(int left, int right)
        {
            var comparer = new AbsComparer();
            return comparer.Compare(left, right); 
        }
    }
}