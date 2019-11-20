using System;
using System.Collections.Generic;
using System.Linq;
using MVC_Library.Model;

namespace MVC_Library.View
{
    public class StatistcReport : IReportVeiw
    {
        private List<WeatherChangedEventArgs> data;
        
        public StatistcReport()
        {
            data = new List<WeatherChangedEventArgs>();
        }
        
        public void Report(object sender, WeatherChangedEventArgs args)
        {
            data.Add(args);
            if (data.Count % 20 == 0 && data.Count != 0)
            {
                double middleTemperature = data.Select(d => d.Temperature).Average();
                double middleHumidate = data.Select(d => d.Humidate).Average();
                double middlePressure = data.Select(d => d.Pressure).Average(); 
                Console.WriteLine("******************************************");
                Console.WriteLine("Middle"
                + $"Temperature {middleTemperature}"
                + $"Humidate {middleHumidate}"
                + $"Pressure {middlePressure}"
                );
                Console.WriteLine("**********************************************");
            }
        }
    }
}