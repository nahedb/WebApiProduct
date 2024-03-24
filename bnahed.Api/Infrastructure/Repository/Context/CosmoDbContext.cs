namespace bnahed.Api.Infrastructure.Repository.Context;

using bnahed.Api.Infrastructure.Repository.Context.Interface;
using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Settings;

public class CosmoDbContext(IOptions<CosmoDbConfigurations> options) : DbContext, ICosmoDbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    private readonly string connectionUri = options.Value.ConnectionUri!;
    private readonly string accountKey = options.Value.AccountKey!;
    private readonly string databaseName = options.Value.DatabaseName!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseCosmos(connectionUri, accountKey, databaseName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WeatherForecast>()
            .ToContainer("Weather")
            .HasPartitionKey(e => e.Id ?? new Guid());
    }
}
