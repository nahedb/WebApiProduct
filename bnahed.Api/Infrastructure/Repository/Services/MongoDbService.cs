namespace bnahed.Api.Infrastructure.Repository.Services;

using Settings;
using Interfaces;
using Models;
using MongoDB.Driver;
using MongoDB.Bson;
using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.Extensions.Options;

public class MongoDbService : IMongoDbService
{
    private readonly IMongoCollection<WeatherForecast> _weatherHistory;

    public MongoDbService(IOptions<MongoDbSettings> settings)
    {
        MongoClient client = new(settings.Value.ConnectionUri);
        IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
        _weatherHistory = database.GetCollection<WeatherForecast>(settings.Value.CollectionName);
    }

    public async Task<bool> UpdateWeatherHistory(IEnumerable<WeatherForecast> weatherForecasts)
    {
        await _weatherHistory.InsertManyAsync(weatherForecasts);
        return true;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherHistory()
    {
        return (await _weatherHistory.FindAsync(new BsonDocument())).ToEnumerable();
    }
}