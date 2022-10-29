using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Interfaces.Services;

namespace WeatherChecker.Core.UseCases.GetCurrentWeather
{
    public class GetCurrentWeatherUseCase : IGetCurrentWeatheUseCase
    {
        private readonly IWeatherService weatherService;

        public GetCurrentWeatherUseCase(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<GetCurrentWeatherResult> ExecuteAsync(GetCurrentWeatherRequest input)
        {
            var weather = await weatherService.GetWeather();

            if (weather == null)
            {
                return new GetCurrentWeatherResult("Weather not found.");
            }

            return new GetCurrentWeatherResult(weather);
        }
    }
}
