using WeatherStation.Subject;

namespace WeatherStation.Observer
{
    public interface IObserver
    {
        void update(double temperature, double humidate, double pressure); 
    }
}