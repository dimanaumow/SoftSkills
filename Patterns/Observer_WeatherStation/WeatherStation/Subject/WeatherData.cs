using System.Collections.Generic;
using WeatherStation.Observer;

namespace WeatherStation.Subject
{
    public class WeatherData : ISubject
    {
        private double temperature;
        private double humidate;
        private double pressure;
        private List<IObserver> observers;  

        public WeatherData()
        {
            observers = new List<IObserver>();
        }
        
        public void RegisterObsrver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObsrever(IObserver ob)
        {
            observers.Remove(ob); 
        }

        public void NotifyObsrvers()
        {
            foreach (var observer in observers)
            {
                observer.update(this.temperature, this.humidate, this.pressure);
            }
        }

        public void MeasurementChanged()
        {
            NotifyObsrvers();
        }

        public void SetMeasurements(double temperature, double humidate, double pressure)
        {
            this.temperature = temperature;
            this.humidate = humidate;
            this.pressure = pressure; 
            
            MeasurementChanged();
        }
    }
}