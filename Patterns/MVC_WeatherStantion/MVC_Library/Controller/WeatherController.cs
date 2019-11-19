using System;
using MVC_Library.Model;

namespace MVC_Library.Controller
{
    public class WeatherController
    {
        
        private WeatherStation station; 
        public delegate void Update(WeatherStation station);

        public WeatherController(WeatherStation station)
        {
            this.station = station;
        }
        
        public static void  WinterUpdate(WeatherStation station)
        {
            
        }

        public static void SummerUpdate(WeatherStation station)
        {
            
        }
    }

    public static class WinterController
    {
        public static void WinterUpdate(WeatherStation station)
        {
            
        }
    }
}