using Newtonsoft.Json;

namespace bnahed.Api.Models.V1.WeatherForecast;

public record WeatherForecast
{
    [JsonProperty("id")]
    public Guid? Id { get; set; }

    public DateTime? Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public void GenerateGuid()
    {
        Id = Guid.NewGuid();
    }
}