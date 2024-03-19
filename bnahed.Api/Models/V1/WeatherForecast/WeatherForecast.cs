namespace bnahed.Api.Models.V1.WeatherForecast;
public record WeatherForecast
{
    public string? Id { get; set; }

    public DateTime? Date { get; init; }

    public int TemperatureC { get; init; }

    public string? Summary { get; init; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}