using Core.Enum;

namespace Core.Entity;

public class BaseEntity
{
    public int Id { get; set; }
    public Status Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}