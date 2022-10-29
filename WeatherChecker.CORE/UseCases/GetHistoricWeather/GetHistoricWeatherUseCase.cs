using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Interfaces.Repository;
using WeatherChecker.Core.Interfaces.Services;
using WeatherChecker.Core.UseCases.GetCurrentWeather;

namespace WeatherChecker.Core.UseCases.GetHistoricWeather
{
    public class GetHistoricWeatherUseCase : IGetHistoricWeatherUseCase
    {
        private readonly IWeatherRepository weatherRepository;

        public GetHistoricWeatherUseCase(IWeatherRepository weatherRepository)
        {
            this.weatherRepository = weatherRepository;
        }

        public async Task<GetHistoricWeatherResult> ExecuteAsync(GetHistoricWeatherRequest input)
        {
            var weather = await weatherRepository.GetWeatherAsync(input.Date);

            if (weather == null)
            {
                return new GetHistoricWeatherResult("Weather not found.");
            }

            return new GetHistoricWeatherResult(weather);
        }
    }
}
