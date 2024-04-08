namespace bnahed.Api.Infrastructure.Repository.Context;

using bnahed.Api.Infrastructure.Repository.Context.Interface;
using bnahed.Api.Models.V1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Settings;

public abstract class CosmoDbContext(IOptions<CosmoDbConfigurations> options) : DbContext, ICosmoDbContext
{
    private DbSet<IEntity> DbSet { get; set; }

    private readonly string connectionUri = options.Value.ConnectionUri!;
    private readonly string accountKey = options.Value.AccountKey!;
    private readonly string databaseName = options.Value.DatabaseName!;

    public void Add(IEntity entity)
    {
        DbSet.Add(entity);

    }

    public void AddRange(IEnumerable<IEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public void Delete(IEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<IEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public void Update(IEntity entity)
    {
        DbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<IEntity> entities)
    {
        DbSet.UpdateRange(entities);
    }

    public void Merge(IEntity entity)
    {
        if (DbSet.Contains(entity))
        {
            Update(entity);
        }

        Add(entity);
    }

    public void MergeRange(IEnumerable<IEntity> entities)
    {
        var existingRecords = entities.Where(e => DbSet.Contains(e));
        var newRecords = entities.Except(existingRecords);
        AddRange(newRecords);
        UpdateRange(newRecords);
    }

    public async Task AddAsync(IEntity entity)
    {
        Add(entity);
        await SaveChanges();

    }

    public async Task AddRangeAsync(IEnumerable<IEntity> entities)
    {
        AddRange(entities);
        await SaveChanges();
    }

    public async Task DeleteAsync(IEntity entity)
    {
        Delete(entity);
        await SaveChanges();
    }

    public async Task DeleteRangeAsync(IEnumerable<IEntity> entities)
    {
        DeleteRange(entities);
        await SaveChanges();
    }

    public async Task UpdateAsync(IEntity entity)
    {
        Update(entity);
        await SaveChanges();
    }

    public async Task UpdateRangeAsync(IEnumerable<IEntity> entities)
    {
        UpdateRange(entities);
        await SaveChanges();
    }

    public async Task MergeAsync(IEntity entity)
    {
        Merge(entity);
        await SaveChanges();
    }

    public async Task MergeRangeAsync(IEnumerable<IEntity> entities)
    {
        MergeRange(entities);
        await SaveChanges();
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<IEntity>> GetAllRecords()
    {
        return await DbSet.ToArrayAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseCosmos(connectionUri, accountKey, databaseName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IEntity>()
            .ToContainer("Weather")
            .HasPartitionKey(e => e.Id);
    }
}
