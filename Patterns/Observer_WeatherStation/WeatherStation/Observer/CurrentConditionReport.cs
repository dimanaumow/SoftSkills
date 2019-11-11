using System;
using WeatherStation.Subject;

namespace WeatherStation.Observer
{
    public class CurrentConditionReport : IObserver, IDisplayData
    {
        private double temperature;
        private double humidate;
        private double pressure;
        private ISubject weatherData;

        public CurrentConditionReport(ISubject weatherData)
        {
            this.weatherData = weatherData; 
            weatherData.RegisterObsrver(this);
        }
        public void update(double temperature, double humidate, double pressure)
        {
            this.temperature = temperature;
            this.humidate = humidate;
            this.pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current tempetaure : {temperature}");
            Console.WriteLine($"Current humidate {humidate}");
            Console.WriteLine($"Current pressure {pressure}");
        }
    }
}