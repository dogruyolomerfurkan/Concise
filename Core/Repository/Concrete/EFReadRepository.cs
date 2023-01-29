using Core.Entity;
using Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repository.Concrete;

public class EFReadRepository<T> : IEFReadRepository<T> where T : BaseEntity, new()
{
    private readonly DbSet<T> _entity;

    public EFReadRepository(DbContext dbContext) { _entity = dbContext.Set<T>(); }

    public DbSet<T> Entity => _entity;

    public IQueryable<T> Get(Expression<Func<T, bool>> filter, bool tracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = _entity.Where(filter).AsQueryable();

        if (!tracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        return query;
    }

    public T? GetById(int id, bool tracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = _entity.AsQueryable();

        if (include != null) query = include(query);

        if (!tracking) query = query.AsNoTracking();

        return query.FirstOrDefault(p => p.Id == id);
    }

    public Task<T?> GetByIdAsync(int id, bool tracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = _entity.AsQueryable();

        if (include != null) query = include(query);

        if (!tracking) query = query.AsNoTracking();

        return query.FirstOrDefaultAsync(p => p.Id == id);
    }

    public int Count(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        IQueryable<T> query = _entity.Where(filter).AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return query.Count();

    }

    public Task<int> CountAsync(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        IQueryable<T> query = _entity.Where(filter).AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return query.CountAsync();
    }
    public bool Any(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        IQueryable<T> query = _entity.Where(filter).AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return query.Any();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        IQueryable<T> query = _entity.Where(filter).AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return query.AnyAsync();
    }
}