using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Interfaces.Repository;
using WeatherChecker.Core.Models;
using WeatherChecker.Core.Queries;
using WeatherChecker.Core.UseCases.GetCurrentWeather;

namespace WeatherChecker.Core.UseCases.SearchWeather
{
    public class SearchWeatherUseCase : ISearchWeatherUseCase
    {
        private readonly IWeatherRepository repository;

        public SearchWeatherUseCase(IWeatherRepository repository)
        {
            this.repository = repository;
        }
        public async Task<SearchWeatherResult> ExecuteAsync(SearchWeatherRequest input)
        {
            var parameters = new WeatherQueryParameters()
            {
                Page = input.Page,
                PageSize = input.PageSize
            };

            var response = await repository.QueryWeatherAsync(parameters);

            if (response == null)
            {
                return new SearchWeatherResult("Weather query had no response.");
            }

            return new SearchWeatherResult(response);
        }
    }
}
