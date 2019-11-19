using MVC_Library.Model;

namespace MVC_Library.View
{
    public class CurrentConditionReport
    {
        public double Temperature { set; private get;  }
        public double Humidate { set; private get; }
        public double Pressure { set; private get; }

        public string Report(object sender, WeatherChangedEventArgs args) =>
            $"Current temperature: {args.Temperature} " +
            $"Current humidate: {args.Humidate}" +
            $"Current pressure: {args.Pressure}"; 
    }
}