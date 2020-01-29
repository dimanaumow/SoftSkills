using System;
using NUnit.Framework;
using TransformToWords;
using TransformToWords.TemplateMethod;

namespace TransformToWords_Test
{
    [TestFixture]
    public class TransformToWordsTests
    {
        [TestCase(double.NaN, ExpectedResult = "Not a number ")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative infinity ")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive infinity ")]
        [TestCase(-0.0d, ExpectedResult = "zero ")]
        [TestCase(0.0d, ExpectedResult = "zero ")]
        [TestCase(0.1d, ExpectedResult = "zero dot one ")]
        [TestCase(-23.809d, ExpectedResult = "minus two three dot eight zero nine ")]
        [TestCase(-0.123456789d, ExpectedResult = "minus zero dot one two three four five six seven eight nine ")]
        [TestCase(1.23333e308d, ExpectedResult = "one dot two three three three three E plus three zero eight ")]
        [TestCase(double.Epsilon, ExpectedResult = "four dot nine four zero six five six four five eight four one two four seven E minus three two four ")]
        [TestCase(double.MinValue, ExpectedResult = "minus one dot seven nine seven six nine three one three four eight six two three two E plus three zero eight ")]
        [TestCase(double.MaxValue, ExpectedResult = "one dot seven nine seven six nine three one three four eight six two three two E plus three zero eight ")]
        public string TransformToDifferentWords_Strategy(double number)
        {
            var provider = new EnglishProvider();
            return number.TransformToWords(provider); 
        }

        [TestCase(double.NaN, ExpectedResult = "Not a number ")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative infinity ")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive infinity ")]
        [TestCase(-0.0d, ExpectedResult = "zero ")]
        [TestCase(0.0d, ExpectedResult = "zero ")]
        [TestCase(0.1d, ExpectedResult = "zero dot one ")]
        [TestCase(-23.809d, ExpectedResult = "minus two three dot eight zero nine ")]
        [TestCase(-0.123456789d, ExpectedResult = "minus zero dot one two three four five six seven eight nine ")]
        [TestCase(1.23333e308d, ExpectedResult = "one dot two three three three three E plus three zero eight ")]
        [TestCase(double.Epsilon, ExpectedResult = "four dot nine four zero six five six four five eight four one two four seven E minus three two four ")]
        [TestCase(double.MinValue, ExpectedResult = "minus one dot seven nine seven six nine three one three four eight six two three two E plus three zero eight ")]
        [TestCase(double.MaxValue, ExpectedResult = "one dot seven nine seven six nine three one three four eight six two three two E plus three zero eight ")]
        public string TransformToDifferentWords_TemplateMethod(double number)
        {
            var transformer = new EnglishTransformer();
            return transformer.TransformToWords(number);
        }
    }
}