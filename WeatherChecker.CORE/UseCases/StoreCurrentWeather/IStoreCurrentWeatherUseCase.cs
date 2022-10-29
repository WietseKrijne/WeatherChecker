using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Interfaces.Common;

namespace WeatherChecker.Core.UseCases.StoreCurrentWeather
{
    public interface IStoreCurrentWeatherUseCase : IBaseUseCase<StoreCurrentWeatherRequest, StoreCurrentWeatherResult>
    {
    }
}
