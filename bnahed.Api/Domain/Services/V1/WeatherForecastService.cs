using bnahed.Api.Domain.Services.V1.Interfaces;
using bnahed.Api.Models.V1.WeatherForecast;

namespace bnahed.Api.Domain;

public class WeatherForecastService() : IWeatherForecastService
{
    private readonly string[] summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public async Task<IEnumerable<WeatherForecast>> GetWeather()
    {
        var weatherToday = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray();

        return await Task.FromResult(weatherToday);
    }

    public async Task<bool> UpdateWeatherHistory(IEnumerable<WeatherForecast> weatherForecasts)
    {
        return await Task.FromResult(true);
    }
}