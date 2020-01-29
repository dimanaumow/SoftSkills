using System.Collections.Generic;
using System.Text;

namespace TransformToWords
{ 
    public static class Transformer
    {
        public static string TransformToWords(this double number, IDictionaryProvider provider) 
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
}