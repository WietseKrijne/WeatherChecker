namespace WeatherChecker.Core.UseCases.SearchWeather
{
    public class SearchWeatherRequest
    {
        public SearchWeatherRequest(int page = 1, int pageSize = 10)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}