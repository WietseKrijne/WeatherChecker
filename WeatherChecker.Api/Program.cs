using WeatherChecker.Core.Interfaces.Repository;
using WeatherChecker.Core.Interfaces.Services;
using WeatherChecker.Core.UseCases.GetCurrentWeather;
using WeatherChecker.Core.UseCases.GetHistoricWeather;
using WeatherChecker.Core.UseCases.SearchWeather;
using WeatherChecker.Core.UseCases.StoreCurrentWeather;
using WeatherChecker.Infrastructure.Repositories;
using WeatherChecker.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IGetCurrentWeatheUseCase, GetCurrentWeatherUseCase>();
builder.Services.AddScoped<IGetHistoricWeatherUseCase, GetHistoricWeatherUseCase>();
builder.Services.AddScoped<ISearchWeatherUseCase, SearchWeatherUseCase>();
builder.Services.AddScoped<IStoreCurrentWeatherUseCase, StoreCurrentWeatherUseCase>();
builder.Services.AddScoped<IWeatherService, WttrWeatherService>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
