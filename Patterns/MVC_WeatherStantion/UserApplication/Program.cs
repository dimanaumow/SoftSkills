using System;
using System.Data;
using MVC_Library.Controller;
using MVC_Library.Model;
using MVC_Library.View;

namespace UserApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WeatherStation station = new WeatherStation();
            WeatherController controller = new WeatherController(station);
            var ViewCurrentReport = new CurrentConditionReport();
            station.WeatherChanged += ViewCurrentReport.Report;
            for (int i = 0; i < 100; i++)
            {
                controller.Controller();
            }
            
        }
    }
}