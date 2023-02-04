using Core.Enum;

namespace Core.Entity;

public class BaseEntity<TId>
{
    public TId Id { get; set; } = default!;
    public Status Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}