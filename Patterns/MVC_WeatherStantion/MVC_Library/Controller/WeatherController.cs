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

        public static void WinterUpdate(WeatherStation station)
        {
            Random rand = new Random();
            station.SetMeasurements(((rand.NextDouble() * 100) % 20) - 15, ((rand.NextDouble() * 100) % 20) + 95, 
                ((rand.NextDouble() * 1000) % 20) + 750 );
        }

        public static void SummerUpdate(WeatherStation station)
        {
            Random rand = new Random();
            station.SetMeasurements(((rand.NextDouble() * 100) % 18) + 12, ((rand.NextDouble() * 100) % 20) + 50, 
                ((rand.NextDouble() * 1000) % 20) + 730);
        }
    }
}