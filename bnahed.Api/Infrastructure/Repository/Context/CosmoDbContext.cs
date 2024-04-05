namespace bnahed.Api.Infrastructure.Repository.Context;

using bnahed.Api.Infrastructure.Repository.Context.Interface;
using bnahed.Api.Models.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Settings;

public abstract class CosmoDbContext<TEntity>(IOptions<CosmoDbConfigurations> options) : DbContext, ICosmoDbContext<TEntity>
    where TEntity : Entity
{
    private DbSet<TEntity> DbSet { get; set; }

    private readonly string connectionUri = options.Value.ConnectionUri!;
    private readonly string accountKey = options.Value.AccountKey!;
    private readonly string databaseName = options.Value.DatabaseName!;

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);

    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbSet.UpdateRange(entities);
    }

    public void Merge(TEntity entity)
    {
        if (DbSet.Contains(entity))
        {
            Update(entity);
        }

        Add(entity);
    }

    public void MergeRange(IEnumerable<TEntity> entities)
    {
        var existingRecords = entities.Where(e => DbSet.Contains(e));
        var newRecords = entities.Except(existingRecords);
        AddRange(newRecords);
        UpdateRange(newRecords);
    }

    public async Task AddAsync(TEntity entity)
    {
        Add(entity);
        await SaveChanges();

    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        AddRange(entities);
        await SaveChanges();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Delete(entity);
        await SaveChanges();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        DeleteRange(entities);
        await SaveChanges();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Update(entity);
        await SaveChanges();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        UpdateRange(entities);
        await SaveChanges();
    }

    public async Task MergeAsync(TEntity entity)
    {
        Merge(entity);
        await SaveChanges();
    }

    public async Task MergeRangeAsync(IEnumerable<TEntity> entities)
    {
        MergeRange(entities);
        await SaveChanges();
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllRecords()
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
        modelBuilder.Entity<TEntity>()
            .ToContainer("Weather")
            .HasPartitionKey(e => e.Id);
    }
}
