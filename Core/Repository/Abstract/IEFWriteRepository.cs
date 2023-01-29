using Core.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repository.Abstract;

public interface IEFWriteRepository<T> : IEFRepository<T> where T : BaseEntity, new()
{
    /// <summary>
    /// Sign entity as <see cref="EntityState.Added" /> to tracking
    /// </summary>
    /// <param name="entity"></param>
    void Add(T entity);

    /// <summary>
    /// Sign entity as <see cref="EntityState.Added" /> to tracking
    /// </summary>
    /// <param name="entity"></param>
    Task AddAsync(T entity);

    /// <summary>
    /// Sign entities as <see cref="EntityState.Added" /> to tracking
    /// </summary>
    /// <param name="entity"></param>
    void AddRange(IEnumerable<T> entities);

    /// <summary>
    /// Sign entities as <see cref="EntityState.Added" /> to tracking
    /// </summary>
    /// <param name="entity"></param>
    Task AddRangeAsync(IEnumerable<T> entities);

    /// <summary>
    /// Sign entity as <see cref="EntityState.Modified" /> if any modification happens. Entity state remains <see cref="EntityState.Unchanged" /> if no modification are made
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Sign entities as <see cref="EntityState.Modified" /> if any modification happens. Entity states remains <see cref="EntityState.Unchanged" /> if no modification are made
    /// </summary>
    /// <param name="entity"></param>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Updates all database rows for the entity instances which match the LINQ query from the database.
    /// Does not interact with the EF Change tracker and does not wait for <see cref="DbContext.SaveChanges()" /> in the process.
    /// See <see href="https://aka.ms/efcore-docs-bulk-operations">Executing bulk operations with EF Core</see> for documentation
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="setPropertyCalls"></param>
    /// <returns></returns>
    int ExecuteUpdate(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

    /// <summary>
    /// Updates all database rows for the entity instances which match the LINQ query from the database.
    /// Does not interact with the EF Change tracker and does not wait for <see cref="DbContext.SaveChanges()" /> in the process.
    /// See <see href="https://aka.ms/efcore-docs-bulk-operations">Executing bulk operations with EF Core</see> for documentation
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="setPropertyCalls"></param>
    /// <returns></returns>
    Task<int> ExecuteUpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

    /// <summary>
    /// Removes all database rows for the entity instances which match the LINQ query from the database.
    /// Does not interact with the EF Change tracker and does not wait for <see cref="DbContext.SaveChanges()" /> in the process.
    /// See <see href="https://aka.ms/efcore-docs-bulk-operations">Executing bulk operations with EF Core</see> for documentation
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    int Remove(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Removes all database rows for the entity instances which match the LINQ query from the database.
    /// Does not interact with the EF Change tracker and does not wait for <see cref="DbContext.SaveChanges()" /> in the process.
    /// See <see href="https://aka.ms/efcore-docs-bulk-operations">Executing bulk operations with EF Core</see> for documentation
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<int> RemoveAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Save all changes made in context to database
    /// </summary>
    /// <returns></returns>
    /// 
    int Save();

    /// <summary>
    /// Save all changes made in context to database
    /// </summary>
    /// <returns></returns>
    Task<int> SaveAsync();
}