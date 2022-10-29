using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using WeatherChecker.Core.Interfaces.Services;
using WeatherChecker.Core.Models;
using System.Reflection.Metadata;
using System.Text.Json;
using WeatherChecker.Infrastructure.Models;
using WeatherChecker.Core.UseCases.GetCurrentWeather;

namespace WeatherChecker.Infrastructure.Services
{
    public class WttrWeatherService : IWeatherService, IDisposable
    {
        private const string baseAddress = "https://wttr.in/";
        private readonly IHttpClientFactory httpClientFactory;
        private HttpClient? _client;

        public WttrWeatherService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public HttpClient Initialize()
        {
            if (_client == null)
            {
                var client = httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(baseAddress);
                _client = client;
            }
            return _client;
        }

        public async Task<Weather> GetWeather()
        {
            var client = Initialize();

            var httpResponse = await client.GetAsync("culemborg?format=j1");
            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<WeatherDataModel>(response);
                if (result == null || result.current_condition == null || !result.current_condition.Any())
                {
                    throw new Exception($"Failed to deserialize json to WeatherDbModel. json response {response}");
                }

                var currentCondition = result.current_condition.First();

                return new Weather(
                    Int32.Parse(currentCondition.temp_C),
                    Int32.Parse(currentCondition.windspeedKmph),
                    Int32.Parse(currentCondition.winddirDegree),
                    Int32.Parse(currentCondition.cloudcover),
                    float.Parse(currentCondition.precipMM),
                    Int32.Parse(currentCondition.FeelsLikeC),
                    DateTime.UtcNow);
            }
            else
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception($"Failed to get weatherData. ResponseCode{httpResponse.StatusCode}. Reason {response}.");
            }
        }

        public void Dispose()
        {
            ((IDisposable?)_client)?.Dispose();
        }


        private class WeatherDataModel
        {
            public IEnumerable<CurrentConditions>? current_condition { get; set; }
        }

        private class CurrentConditions
        {
            public string temp_C { get; set; }
            public string windspeedKmph { get; set; }
            public string winddirDegree { get; set; }
            public string cloudcover { get; set; }
            public string FeelsLikeC { get; set; }
            public string precipMM { get; set; }
        }
    }
}
