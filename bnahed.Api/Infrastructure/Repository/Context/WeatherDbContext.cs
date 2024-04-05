using bnahed.Api.Infrastructure.Repository.Settings;
using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.Extensions.Options;

namespace bnahed.Api.Infrastructure.Repository.Context
{
    public class WeatherDbContext : CosmoDbContext<WeatherForecast>
    {
        public WeatherDbContext(IOptions<CosmoDbConfigurations> options) : base(options)
        {
        }
    }
}
