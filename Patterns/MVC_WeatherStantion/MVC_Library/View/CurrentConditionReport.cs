using System;
using MVC_Library.Model;

namespace MVC_Library.View
{
    public class CurrentConditionReport
    {
        public double Temperature { set; private get;  }
        public double Humidate { set; private get; }
        public double Pressure { set; private get; }

        public void Report(object sender, WeatherChangedEventArgs args)
        {
            Console.WriteLine("Current" 
             + $"    Temperature {args.Temperature}"
             + $"    Humidate {args.Humidate}"
             + $"    Pressure {args.Pressure}");
           
        }
    }
}