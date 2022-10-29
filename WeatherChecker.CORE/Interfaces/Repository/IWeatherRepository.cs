using WeatherChecker.Core.Models;
using WeatherChecker.Core.Queries;

namespace WeatherChecker.Core.Interfaces.Repository
{
    public interface IWeatherRepository
    {
        public Task AddWeatherAsync(Weather weather);
        public Task<Weather> GetWeatherAsync(DateTime dateTime);
        public Task<WeatherQueryResponse> QueryWeatherAsync(WeatherQueryParameters parameters);
    }
}
