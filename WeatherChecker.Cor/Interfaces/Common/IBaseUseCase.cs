namespace WeatherChecker.Core.Interfaces.Common
{
    public interface IBaseUseCase<Tin, TOut>
    {
        public Task<TOut> ExecuteAsync(Tin input);
    }
}
