using WeatherChecker.Core.Models;

namespace WeatherChecker.Api.Dtos
{
    public class WeatherDto
    {
        public WeatherDto(Weather weather)
        {
            Temperature = weather.Temperature;
            WindSpeed = weather.WindSpeed;
            WindDirection = weather.WindDirection;
            CloudCover = weather.CloudCover;
            WindChill = weather.WindChill;
            Precipitation = weather.Precipation;
            Date = weather.Date;
        }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public int CloudCover { get; set; }
        public int Humidity { get; set; }
        public int WindChill { get; set; }
        public float Precipitation { get; set; }
        public DateTime Date { get; set; }
    }
}
