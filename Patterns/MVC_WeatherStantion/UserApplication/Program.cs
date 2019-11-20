using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
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
            var data = new List<IReportVeiw>
            {
                new CurrentConditionReport(),
                new StatistcReport()
            };
            WeatherController controller = new WeatherController(station, data);
            for (int i = 0; i < 100; i++)
            {
                controller.Update();
            }
            //TODO : System.Timers.Timer; 
        }
    }
}