using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChecker.Core.Models;

namespace WeatherChecker.Core.Queries
{
    public class WeatherQueryResponse
    {
        public WeatherQueryResponse(IEnumerable<Weather> response, int total, int page, int pageSize)
        {
            Response = response;
            Total = total;
            Page = page;
            PageSize = pageSize;
        }

        public IEnumerable<Weather> Response { get; }
        public int Total { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}
