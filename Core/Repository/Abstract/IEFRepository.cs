using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Abstract;

public interface IEFRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Entity { get; }
}
