namespace bnahed.Api.Domain.Services.V1.Interfaces;

using Models.V1.WeatherForecast;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetWeather();

    Task<bool> UpdateWeatherHistory(IEnumerable<WeatherForecast> weatherForecasts);
}