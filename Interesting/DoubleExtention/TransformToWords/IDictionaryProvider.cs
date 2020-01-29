using System.Collections.Generic;

namespace TransformToWords
{
    
    public interface IDictionaryProvider
    {
        Dictionary<char, string> Keys {get;}
	
        Dictionary<double, string> SpecialKeys {get;}
    }
}