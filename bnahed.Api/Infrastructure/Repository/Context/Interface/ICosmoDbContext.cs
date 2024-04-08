using bnahed.Api.Models.V1.Interfaces;

namespace bnahed.Api.Infrastructure.Repository.Context.Interface;

public interface ICosmoDbContext
{
    void Add(IEntity entity);

    void Delete(IEntity entity);

    void AddRange(IEnumerable<IEntity> entities);

    void DeleteRange(IEnumerable<IEntity> entities);

    void Merge(IEntity entity);

    void Update(IEntity entity);

    void MergeRange(IEnumerable<IEntity> entities);

    void UpdateRange(IEnumerable<IEntity> entities);

    Task AddAsync(IEntity entity);

    Task DeleteAsync(IEntity entity);

    Task AddRangeAsync(IEnumerable<IEntity> entities);

    Task DeleteRangeAsync(IEnumerable<IEntity> entities);

    Task MergeAsync(IEntity entity);

    Task UpdateAsync(IEntity entity);

    Task MergeRangeAsync(IEnumerable<IEntity> entities);

    Task UpdateRangeAsync(IEnumerable<IEntity> entities);

    Task<IEnumerable<IEntity>> GetAllRecords();

    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}