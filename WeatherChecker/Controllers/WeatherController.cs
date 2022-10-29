using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WeatherChecker.Api.Dtos;
using WeatherChecker.Core.Models;
using WeatherChecker.Core.UseCases.GetCurrentWeather;

namespace WeatherChecker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<WeatherDto>> GetCurrentWeather([FromServices] IGetCurrentWeatheUseCase useCase)
        {
            var request = new GetCurrentWeatherRequest();
            var result = await useCase.ExecuteAsync(request);

            if (!result.Success)
            {
                return Conflict(result.Message);
            }

            return Ok(result.Result);
        }

        [HttpGet("/IsTheWeatherGood")]
        public async Task<ActionResult<string>> IsItGood([FromServices] IGetCurrentWeatheUseCase useCase)
        {
            var request = new GetCurrentWeatherRequest();
            var result = await useCase.ExecuteAsync(request);

            if (!result.Success)
            {
                return Conflict(result.Message);
            }

            var weatherComfortable = CheckWeatherComfort(result.Result!);

            if (weatherComfortable)
            {
                return Ok("Yes! Go outside!");
            }
            else
            {
                return Ok("No! Stay inside!");
            }
        }

        private bool CheckWeatherComfort(Weather weather)
        {
            if (weather.CloudCover < 50 && //to cloudy
                weather.WindChill < 40 && //to hot
                weather.WindChill > 18 && //to cold
                weather.Precipation == 0 && // to rainy
                weather.WindSpeed < 12) // To Windy
            {
                return true;
            }
            return false;
        }
    }
}
