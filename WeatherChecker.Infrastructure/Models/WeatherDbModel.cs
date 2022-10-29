using Dapper;
using WeatherChecker.Core.Models;

namespace WeatherChecker.Infrastructure.Models
{
    [Table("Weather")]
    public class WeatherDbModel
    {
        public WeatherDbModel() { }
        public WeatherDbModel(Weather weather)
        {
            Temperature = weather.Temperature;
            WindSpeed = weather.WindSpeed;
            WindDirection = weather.WindDirection;
            CloudCover = weather.CloudCover;
            WindChill = weather.WindChill;
            Precipation = weather.Precipation;
            Date = weather.Date;
        }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public int CloudCover { get; set; }
        public int WindChill { get; set; }
        public float Precipation { get;set; }
        public DateTime Date { get; set; }
        public Weather ToRecord()
        {
            return new Weather(Temperature, WindSpeed, WindDirection, CloudCover, Precipation, WindChill, Date);
        }
    }
}
