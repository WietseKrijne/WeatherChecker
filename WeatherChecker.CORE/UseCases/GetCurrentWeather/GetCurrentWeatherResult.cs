using WeatherChecker.Core.Common;
using WeatherChecker.Core.Models;

namespace WeatherChecker.Core.UseCases.GetCurrentWeather
{
    public class GetCurrentWeatherResult : BaseResult<Weather>
    {
        public GetCurrentWeatherResult(Weather result) : base(result)
        {
        }

        public GetCurrentWeatherResult(string message) : base(message)
        {
        }
    }
}