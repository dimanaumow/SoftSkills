
using WeatherStation.Observer;

namespace WeatherStation.Subject
{
    public interface ISubject
    
    {
        void RegisterObsrver(IObserver ob);
        void RemoveObsrever(IObserver ob);
        void NotifyObsrvers(); 
    }
}