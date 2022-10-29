using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Models;

namespace WeatherChecker.Core.Interfaces.Services
{
    public interface IWeatherService
    {
        public Task<Weather> GetWeather();
    }
}
