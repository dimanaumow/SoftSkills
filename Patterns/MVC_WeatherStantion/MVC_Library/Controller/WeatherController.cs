using System;
using System.Collections.Generic;
using System.Threading;
using MVC_Library.Model;
using MVC_Library.View;

namespace MVC_Library.Controller
{
    public class WeatherController
    {
        private WeatherStation station;
        private IEnumerable<IReportVeiw> reportVeiws;
        
        //public delegate void Update(WeatherStation station);
        public WeatherController(WeatherStation station,
            IEnumerable<IReportVeiw> reportViews)
        {
            this.station = station; 
            foreach (var view in reportViews)
            {
                station.WeatherChanged += view.Report; 
            }
        }
        
        public void Update()
        {
            int Month = DateTime.Now.Month;
            if (Month >= 9 || Month <= 3)
            {
                WinterUpdate(station);
            }
            else
            {
                SummerUpdate(station);
            }
        }

        private static void WinterUpdate(WeatherStation station)
        {
            Random rand = new Random();
            station.SetMeasurements(((rand.NextDouble() * 100) % 20) - 15, ((rand.NextDouble() * 100) % 20) + 95, 
                ((rand.NextDouble() * 1000) % 20) + 750);
            Thread.Sleep(1000);
        }

        private static void SummerUpdate(WeatherStation station)
        {
            Random rand = new Random();
            station.SetMeasurements(((rand.NextDouble() * 100) % 18) + 12, ((rand.NextDouble() * 100) % 20) + 50, 
                ((rand.NextDouble() * 1000) % 20) + 730);
            Thread.Sleep(1000);
        }
    }
}