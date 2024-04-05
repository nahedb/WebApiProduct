using bnahed.Api.Domain.Services.V1.Interfaces;
using bnahed.Api.Infrastructure.Repository.Context.Interface;
using bnahed.Api.Models.V1.WeatherForecast;

namespace bnahed.Api.Domain;

public class WeatherForecastService(ICosmoDbContext<WeatherForecast> cosmoDbContext) : IWeatherForecastService
{
    private readonly string[] summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public async Task<IEnumerable<WeatherForecast>> GetWeather()
    {
        var getWeatherHistory = cosmoDbContext.GetAllRecords();
        var weatherToday = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray();

        return weatherToday.Concat(await getWeatherHistory);
    }

    public async Task<bool> UpdateWeatherHistory(IEnumerable<WeatherForecast> weatherForecasts)
    {
        await cosmoDbContext.AddRangeAsync(weatherForecasts);
        return true;
    }
}