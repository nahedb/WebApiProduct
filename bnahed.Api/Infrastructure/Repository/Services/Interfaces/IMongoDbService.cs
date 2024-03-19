using bnahed.Api.Models.V1.WeatherForecast;

namespace bnahed.Api.Infrastructure.Repository.Services.Interfaces;

public interface IMongoDbService
{
    Task<bool> UpdateWeatherHistory(IEnumerable<WeatherForecast> weatherForecasts);

    Task<IEnumerable<WeatherForecast>> GetWeatherHistory();
}