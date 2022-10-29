using WeatherChecker.Core.Common;

namespace WeatherChecker.Core.UseCases.StoreCurrentWeather
{
    public class StoreCurrentWeatherResult : BaseResult
    {
        public StoreCurrentWeatherResult() { }

        public StoreCurrentWeatherResult(string message) : base(message) { }
    }
}