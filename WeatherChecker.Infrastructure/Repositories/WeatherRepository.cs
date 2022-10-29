using Dapper;
using WeatherChecker.Core.Interfaces.Repository;
using WeatherChecker.Core.Models;
using WeatherChecker.Core.Queries;
using WeatherChecker.Infrastructure.Common;
using WeatherChecker.Infrastructure.Models;

namespace WeatherChecker.Infrastructure.Repositories
{
    public class WeatherRepository : BaseDatabase, IWeatherRepository
    {
        public  async Task AddWeatherAsync(Weather model)
        {
            var dbModel = new WeatherDbModel(model);

            await Connection().InsertAsync(dbModel);
        }

        public async Task<Weather> GetWeatherAsync(DateTime dateTime)
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("requestedDate", dateTime);
            var dbModel = await Connection().QueryFirstAsync<WeatherDbModel>("SELECT TOP 1 * FROM Weather WHERE date < @requestedDate ORDER BY d.date DESC",parameters);
            return dbModel.ToRecord();
        }

        public async Task<WeatherQueryResponse> QueryWeatherAsync(WeatherQueryParameters parameters)
        {
            var total = await Connection().RecordCountAsync<WeatherDbModel>();
            var dbModels = await Connection().GetListPagedAsync<WeatherDbModel>(parameters.Page, parameters.PageSize, string.Empty, nameof(WeatherDbModel.Date));

            return new WeatherQueryResponse(dbModels.Select(m => m.ToRecord()), total, parameters.Page, parameters.PageSize);
        }
    }
}
