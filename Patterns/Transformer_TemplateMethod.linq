<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
</Query>

void Main()
{
	Transformer Etransformer = new EnglishTransformer(); 
	double number = -10.123; 
	Etransformer.TransformToWords(number).Dump(); 
	Etransformer.TransformToWords(double.NaN).Dump(); 
	Etransformer.TransformToWords(double.PositiveInfinity).Dump(); 
	Etransformer.TransformToWords(double.NegativeInfinity).Dump(); 
	Etransformer.TransformToWords(double.Epsilon).Dump(); 
	Etransformer.TransformToWords(double.MinValue).Dump(); 
	Etransformer.TransformToWords(double.MaxValue).Dump(); 
}

public abstract class Transformer
{
	protected abstract Dictionary<char, string> Keys {get;}
	
	protected abstract Dictionary<double, string> SpecialKeys {get;}
	
	public string TransformToWords(double number) 
	{
		bool flag = SpecialKeys.TryGetValue(number, out string result);
		if(flag)
		{
			return result; 
		}
		string value = number.ToString(System.Globalization.CultureInfo.InvariantCulture); 
		StringBuilder builder = new StringBuilder(); 
		foreach(var t in value)
		{
			builder.Append($"{Keys[t]} ");
		}
		result = builder.ToString(); 
		return result;   
	}
	
}

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
				{'8', "eigth"}, 
				{'9', "nine"}, 
				{'-', "minus"}, 
				{'.', "dot"},  
				{'E', "Е"},
				{'+', "plus"},
			};
			
			protected override Dictionary<double, string> SpecialKeys 
			=> new Dictionary<double, string>
			{
				{double.NaN, "Not a number"}, 
				{double.PositiveInfinity, "positive Infinity"}, 
				{double.NegativeInfinity, "negative infinity"}, 
			};				
}
//Template method