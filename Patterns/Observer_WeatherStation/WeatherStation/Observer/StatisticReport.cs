using System;
using System.Collections.Generic;
using System.Configuration;
using WeatherStation.Subject;

namespace WeatherStation.Observer
{
    public class StatisticReport : IObserver, IDisplayData
    {
        private List<double> temperature;
        private List<double> humidate;
        private List<double> pressure;
        private ISubject weatherData;
        private double maxTemperature;
        private double minTemperature;
        private double MiddleTemperature;
            
        private double maxHumidate;
        private double minHumidate;
        private double MiddleHumidate;
            
        private double maxPressure;
        private double minPressure;
        private double MiddlePressure;

        public StatisticReport(ISubject weatherData)
        {
            temperature = new List<double>();
            humidate = new List<double>();
            pressure = new List<double>();
            
            this.weatherData = weatherData;
            weatherData.RegisterObsrver(this); 
        }
        
        public void Display()
        {
            SetHumidateStatistic();
            SetTemperatureStatistic();
            SetPressureStatistic();
            
            Console.WriteLine($"Max temperatur {maxTemperature}");
            Console.WriteLine($"Min temperatur {minTemperature}");
            Console.WriteLine($"Middle temperatur {MiddleTemperature}");
            Console.WriteLine($"Max humidate {maxHumidate}");
            Console.WriteLine($"Min humidate {minHumidate}");
            Console.WriteLine($"Middle humidate {MiddleHumidate}");
            Console.WriteLine($"Max pressure {maxPressure}");
            Console.WriteLine($"Min pressure {minPressure}");
            Console.WriteLine($"Middle pressure {MiddlePressure}");
        }

        private void SetTemperatureStatistic()
        {
            maxTemperature = temperature[0];
            minTemperature = temperature[0];
            MiddleTemperature = 0;
            foreach (var t in temperature)
            {
                if (t > maxTemperature)
                    maxTemperature = t;
                if (t < minTemperature)
                    minTemperature = t;
                MiddleTemperature += t; 
            }

            MiddleTemperature /= temperature.Count; 
        }
        
        private void SetHumidateStatistic()
        {
            maxHumidate = humidate[0];
            minHumidate = humidate[0];
            MiddleHumidate = 0;
            foreach (var t in humidate)
            {
                if (t > maxHumidate)
                    maxHumidate = t;
                if (t < minHumidate)
                    minHumidate = t;
                MiddleHumidate += t; 
            }

            MiddleHumidate /= humidate.Count; 
        }
        
        private void SetPressureStatistic()
        {
            maxPressure = pressure[0];
            minPressure = pressure[0];
            MiddlePressure = 0;
            foreach (var t in pressure)
            {
                if (t > maxPressure)
                    maxPressure= t;
                if (t < minPressure)
                    minPressure = t;
                MiddlePressure += t; 
            }

            MiddlePressure /= pressure.Count; 
        }
        
        public void update(double temperature, double humidate, double pressure)
        {
            this.temperature.Add(temperature);
            this.humidate.Add(humidate);
            this.pressure.Add(pressure);
            Display();
        }
    }
}