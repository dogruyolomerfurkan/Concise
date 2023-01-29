using Core.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repository.Abstract;

public interface IEFReadRepository<T> : IEFRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> Get(Expression<Func<T, bool>> filter, bool tracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    T? GetById(int id, bool tracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task<T?> GetByIdAsync(int id, bool tracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    bool Any(Expression<Func<T, bool>> filter, bool tracking = true);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter, bool tracking = true);
    int Count(Expression<Func<T, bool>> filter, bool tracking = true);
    Task<int> CountAsync(Expression<Func<T, bool>> filter, bool tracking = true);
}
