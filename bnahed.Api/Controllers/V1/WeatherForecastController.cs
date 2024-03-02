using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using bnahed.Api.Domain.Services.V1.Interfaces;
using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace bnahed.Api.Controllers.V1;

[ApiController]
[Route("v1/[controller]")]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class WeatherForecastController(
    ILogger<WeatherForecastController> logger,
    IWeatherForecastService weatherForecastService) : ControllerBase
{
    [HttpGet(Name = "WeatherForecast")]
    public IActionResult Get()
    {
        return Ok(weatherForecastService.GetWeather());
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}