using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Abstract;

public interface IEFRepository<T, TId> where T : BaseEntity<TId>, new()
{
    DbSet<T> Entity { get; }
}
