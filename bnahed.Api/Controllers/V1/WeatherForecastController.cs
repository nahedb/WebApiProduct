using bnahed.Api.Domain.Services.V1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bnahed.Api.Controllers.V1;

[ApiController]
[Route("v1/[controller]")]
public class WeatherForecastController(
    ILogger<WeatherForecastController> logger,
    IWeatherForecastService weatherForecastService) : ControllerBase
{
    [HttpGet(Name = "WeatherForecast")]
    public IActionResult Get()
    {
        return Ok(weatherForecastService.GetWeather());
    }
}