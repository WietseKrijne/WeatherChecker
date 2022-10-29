using WeatherChecker.Core.Common;
using WeatherChecker.Core.Models;

namespace WeatherChecker.Core.UseCases.GetHistoricWeather
{
    public class GetHistoricWeatherResult : BaseResult<Weather>
    {
        public GetHistoricWeatherResult(Weather result) : base(result)
        {
        }

        public GetHistoricWeatherResult(string message) : base(message)
        {
        }
    }
}