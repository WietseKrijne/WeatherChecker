namespace WeatherChecker.Core.UseCases.GetHistoricWeather
{
    public class GetHistoricWeatherRequest
    {
        public GetHistoricWeatherRequest(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; }
    }
}