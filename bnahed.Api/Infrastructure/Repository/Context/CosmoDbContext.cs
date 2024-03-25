namespace bnahed.Api.Infrastructure.Repository.Context;

using bnahed.Api.Infrastructure.Repository.Context.Interface;
using bnahed.Api.Models.V1.WeatherForecast;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Settings;
using System.Security.Cryptography.X509Certificates;

public class CosmoDbContext(IOptions<CosmoDbConfigurations> options) : DbContext, ICosmoDbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    private readonly string connectionUri = options.Value.ConnectionUri!;
    private readonly string accountKey = options.Value.AccountKey!;
    private readonly string databaseName = options.Value.DatabaseName!;

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<WeatherForecast>> GetAllRecords()
    {
        return await WeatherForecasts.ToArrayAsync();
    }

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
            .HasPartitionKey(e => e.Id);
    }
}
