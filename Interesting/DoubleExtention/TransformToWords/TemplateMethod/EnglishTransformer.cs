using System.Collections.Generic;

namespace TransformToWords.TemplateMethod
{
    public class EnglishTransformer : Transformer
    {
        protected override Dictionary<char, string> Keys 
            => new Dictionary<char, string>
            {
                {'0', "zero"}, 
                {'1', "one"}, 
                {'2', "two"}, 
                {'3', "three"}, 
                {'4', "four"}, 
                {'5', "five"},
                {'6', "six"}, 
                {'7', "seven"}, 
                {'8', "eight"}, 
                {'9', "nine"}, 
                {'-', "minus"}, 
                {'.', "dot"},  
                {'E', "E"},
                {'+', "plus"},
            };
			
        protected override Dictionary<double, string> SpecialKeys 
            => new Dictionary<double, string>
            {
                {double.NaN, "Not a number "}, 
                {double.PositiveInfinity, "Positive infinity "}, 
                {double.NegativeInfinity, "Negative infinity "}, 
            };	
    }
}