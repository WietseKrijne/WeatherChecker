using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Interfaces.Repository;
using WeatherChecker.Core.Interfaces.Services;

namespace WeatherChecker.Core.UseCases.StoreCurrentWeather
{
    public class StoreCurrentWeatherUseCase : IStoreCurrentWeatherUseCase
    {
        private readonly IWeatherRepository weatherRepository;
        private readonly IWeatherService weatherService;

        public StoreCurrentWeatherUseCase(IWeatherRepository weatherRepository, IWeatherService weatherService)
        {
            this.weatherRepository = weatherRepository;
            this.weatherService = weatherService;
        }
        public async Task<StoreCurrentWeatherResult> ExecuteAsync(StoreCurrentWeatherRequest input)
        {
            var currentWeather = await weatherService.GetWeather();

            if (currentWeather == null)
            {
                return new StoreCurrentWeatherResult("Weather not found.");
            }

            await weatherRepository.AddWeatherAsync(currentWeather);

            return new StoreCurrentWeatherResult();
        }
    }
}
