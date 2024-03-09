namespace bnahed.Api.Models.V1.WeatherForecast;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public record WeatherForecast
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("date")]
    public DateTime? Date { get; init; }

    [BsonElement("temperatureC")]
    public int TemperatureC { get; init; }

    [BsonElement("summary")]
    public string? Summary { get; init; }

    [BsonElement("temperatureF")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}