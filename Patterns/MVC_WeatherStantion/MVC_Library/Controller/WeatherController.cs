using System;
using MVC_Library.Model;

namespace MVC_Library.Controller
{
    public class WeatherController
    {
        
        private WeatherStation station; 
        //public delegate void Update(WeatherStation station);

        public WeatherController(WeatherStation station)
        {
            this.station = station;
        }

        public void Controller()
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
        public static void  WinterUpdate(WeatherStation station)
        {
            Random rand = new Random();
            station.Temperature = ((rand.NextDouble() * 100) % 20) - 15;
            station.Humidate = ((rand.NextDouble() * 100) % 20) + 95;
            station.Pressure = ((rand.NextDouble() * 1000) % 20) + 750; 
        }

        public static void SummerUpdate(WeatherStation station)
        {
            Random rand = new Random();
            station.Temperature = ((rand.NextDouble() * 100) % 18) + 12;
            station.Humidate = ((rand.NextDouble() * 100) % 20) + 50;
            station.Pressure = ((rand.NextDouble() * 1000) % 20) + 730; 
        }
    }

    public static class WinterController
    {
        public static void WinterUpdate(WeatherStation station)
        {
            
        }
    }
}