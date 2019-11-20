using System;
using MVC_Library.Model;

namespace MVC_Library.View
{
    public class CurrentConditionReport : IReportVeiw
    {
        public void Report(object sender, WeatherChangedEventArgs args)
        {
            Console.WriteLine("Current" 
             + $"    Temperature {args.Temperature}"
             + $"    Humidate {args.Humidate}"
             + $"    Pressure {args.Pressure}");
        }
    }
}