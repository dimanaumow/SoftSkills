<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
</Query>

void Main()
{
	Transformer Etransformer = new Transformer(); 
	double number = -10.123; 
	Etransformer.TransformToWords(number, new EnglishProvider()).Dump(); 
	Etransformer.TransformToWords(double.NaN, new EnglishProvider()).Dump(); 
	Etransformer.TransformToWords(double.PositiveInfinity, new EnglishProvider()).Dump(); 
	Etransformer.TransformToWords(double.NegativeInfinity, new EnglishProvider()).Dump(); 
	Etransformer.TransformToWords(double.Epsilon, new EnglishProvider()).Dump(); 
	Etransformer.TransformToWords(double.MinValue, new EnglishProvider()).Dump(); 
	Etransformer.TransformToWords(double.MaxValue, new EnglishProvider()).Dump(); 
}

public interface IDictionaryProvider
{
	Dictionary<char, string> Keys {get;}
	
	Dictionary<double, string> SpecialKeys {get;}
}

public class Transformer
{
	public int Y {get => 8; set{Y = value;}} 
	public string TransformToWords(double number, IDictionaryProvider provider) 
	{
		
		bool flag = provider.SpecialKeys.TryGetValue(number, out string result);
		if(flag)
		{
			return result; 
		}
		string value = number.ToString(System.Globalization.CultureInfo.InvariantCulture); 
		StringBuilder builder = new StringBuilder(); 
		foreach(var t in value)
		{
			builder.Append($"{provider.Keys[t]} ");
		}
		result = builder.ToString(); 
		return result;   
	}
	
}

public class EnglishProvider : IDictionaryProvider
{	
	public Dictionary<char, string> Keys => new Dictionary<char, string>
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
	
	public Dictionary<double, string> SpecialKeys => new Dictionary<double, string>
	{
		{double.NaN, "Not a number"}, 
		{double.PositiveInfinity, "positive Infinity"}, 
		{double.NegativeInfinity, "negative infinity"}, 
	};
}
// Strategy