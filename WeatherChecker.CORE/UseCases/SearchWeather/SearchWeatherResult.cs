using WeatherChecker.Core.Common;
using WeatherChecker.Core.Models;
using WeatherChecker.Core.Queries;

namespace WeatherChecker.Core.UseCases.SearchWeather
{
    public class SearchWeatherResult : BaseResult<WeatherQueryResponse>
    {
        public SearchWeatherResult(WeatherQueryResponse result) : base(result)
        {
        }

        public SearchWeatherResult(string message) : base(message)
        {
        }
    }
}