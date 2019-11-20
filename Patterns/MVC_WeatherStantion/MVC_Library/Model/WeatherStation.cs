using System;

namespace MVC_Library.Model
{
    
    public sealed class WeatherStation
    {
        #region Fields

        private double temperature;
        private double humidate;
        private double pressure;
        
        #endregion
        public event EventHandler<WeatherChangedEventArgs> WeatherChanged;

        private void OnWeatherChanged(object sender, WeatherChangedEventArgs args)
        {
            var temp = WeatherChanged; 
            temp?.Invoke(this, args);
        }


        public void SetMeasurements(double temperature, double humidate, double pressure)
        {
            this.temperature = temperature;
            this.humidate = humidate;
            this.pressure = pressure;
            
            this.OnWeatherChanged(this, new WeatherChangedEventArgs()
            {
                Temperature = temperature,
                Humidate = humidate,
                Pressure = pressure
            });
        }
    }

    public class WeatherChangedEventArgs : EventArgs
    {
        public double Temperature { get; set; } 
        public double Humidate { get; set; }
        public double Pressure { get; set; }
    }
}