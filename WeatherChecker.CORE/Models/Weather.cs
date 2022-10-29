using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChecker.Core.Models
{
    public record Weather
    {
        public Weather(int temperature, int windspeed, int windDirection, int cloudCover, float precipation, int windchill, DateTime date)
        {
            Temperature = temperature;
            WindSpeed = windspeed;
            WindDirection = windDirection;
            CloudCover = cloudCover;
            Precipation = precipation;
            WindChill = windchill;
            Date = date;
        }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public int CloudCover { get; set; }
        public int WindChill { get; set; }
        public DateTime Date { get; set; }
        public float Precipation { get; set; }
    }
}
