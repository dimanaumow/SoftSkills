using WeatherStation.Observer;
using WeatherStation.Subject;

namespace WeatherObserverClient

{
    internal class ConsoleClient
    {
        public static void Main(string[] args)
        {
            WeatherData weatherData= new WeatherData();
            
            var currentConditionReport = new CurrentConditionReport(weatherData);
            var statisticReport = new StatisticReport(weatherData);
            
            weatherData.SetMeasurements(14, 67.7, 45);
            weatherData.SetMeasurements(15, 56.4, 34.2);
            weatherData.SetMeasurements(18, 60.3, 64);

            statisticReport.Display();
        }
    }
}