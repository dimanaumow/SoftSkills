using System.Collections.Generic;
using System.Text;

namespace TransformToWords.TemplateMethod
{
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
}