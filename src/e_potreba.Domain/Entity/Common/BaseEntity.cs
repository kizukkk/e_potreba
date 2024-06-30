namespace e_potreba.Domain.Entity.Common;
public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset DateTimeModify{ get; set; } = DateTimeOffset.Now;
}
