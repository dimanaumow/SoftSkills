using System;

namespace MVC_Library.Model
{
    
    public class WeatherStation
    {
        #region Fields
        private double temperature;
        private double humidate;
        private double pressure;

        #endregion

        #region Property

        public double Temperature { set; private get; }
        public double Humidate { set; private get; }
        public double Pressure { set; private get; }

        #endregion
        public event EventHandler<WeatherChangedEventArgs> WeatherChanged;

        protected virtual void OnWeatherChanged(object sender, WeatherChangedEventArgs args)
        {
            var temp = WeatherChanged; 
            temp?.Invoke(this, args);
        }


        public void SetMeasurements(double temperature, double humidate, double pressure)
        {
            Temperature = temperature;
            Humidate = humidate;
            Pressure = pressure; 
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