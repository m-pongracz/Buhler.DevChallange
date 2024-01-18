using Microsoft.EntityFrameworkCore;

namespace Buhler.DevChallenge.Persistence;

public class EfRepositoryBase<TKey, TEntity> where TEntity : class
{
    protected readonly DevChallengeDbContext DbContext;
    protected readonly DbSet<TEntity> Entities;

    public EfRepositoryBase(DevChallengeDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = DbContext.Set<TEntity>();
    }
    
    public virtual Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return Entities.FindAsync(new object[] { id! }, cancellationToken).AsTask();
    }
    
    public virtual async Task<UnsavedContext> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entities.AddAsync(entity, cancellationToken);

        return new UnsavedContext(DbContext);
    }
    
    public virtual async Task<UnsavedContext> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Entities.AddRangeAsync(entities, cancellationToken);

        return new UnsavedContext(DbContext);
    }
    
    public virtual UnsavedContext Update(TEntity entity)
    {
        Entities.Update(entity);

        return new UnsavedContext(DbContext);
    }

    public void ClearChangeTracker()
    {
        DbContext.ChangeTracker.Clear();
    }
}