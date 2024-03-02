namespace bnahed.Api.Domain.Services.V1.Interfaces;

using Models.V1.WeatherForecast;

public interface IWeatherForecastService
{
    public IEnumerable<WeatherForecast> GetWeather();
}