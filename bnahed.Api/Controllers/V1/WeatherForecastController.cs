using bnahed.Api.Domain.Services.V1.Interfaces;
using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace bnahed.Api.Controllers.V1;

[ApiController]
[Route("v1/[controller]")]
public class WeatherForecastController(IWeatherForecastService weatherForecastService) : ControllerBase
{
    [HttpGet(Name = "WeatherForecast")]
    public async Task<IActionResult> Get()
    {
        return Ok(await weatherForecastService.GetWeather());
    }

    [HttpPut(Name = "SaveWeatherForecast")]
    public async Task<IActionResult> Save(IEnumerable<WeatherForecast> weatherForecasts)
    {
        return CreatedAtAction(nameof(Save), await weatherForecastService.UpdateWeatherHistory(weatherForecasts));
    }
}