using bnahed.Api.Models.V1.Interfaces;

namespace bnahed.Api.Infrastructure.Repository.Context.Interface;

public interface ICosmoDbContext<TEntity>
    where TEntity : IEntity
{
    void Add(TEntity entity);

    void Delete(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void DeleteRange(IEnumerable<TEntity> entities);

    void Merge(TEntity entity);

    void Update(TEntity entity);

    void MergeRange(IEnumerable<TEntity> entities);

    void UpdateRange(IEnumerable<TEntity> entities);

    Task AddAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    Task DeleteRangeAsync(IEnumerable<TEntity> entities);

    Task MergeAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task MergeRangeAsync(IEnumerable<TEntity> entities);

    Task UpdateRangeAsync(IEnumerable<TEntity> entities);

    Task<IEnumerable<TEntity>> GetAllRecords();

    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}