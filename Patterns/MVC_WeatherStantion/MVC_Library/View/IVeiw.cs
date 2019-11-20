using MVC_Library.Model;

namespace MVC_Library.View
{
    public interface IReportVeiw
    {
        void Report(object sender, WeatherChangedEventArgs args);
    }
}