using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.EntityFrameworkCore;

namespace bnahed.Api.Infrastructure.Repository.Context.Interface;

public interface ICosmoDbContext
{
    DbSet<WeatherForecast> WeatherForecasts { get; set; }

    Task<IEnumerable<WeatherForecast>> GetAllRecords();

    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}