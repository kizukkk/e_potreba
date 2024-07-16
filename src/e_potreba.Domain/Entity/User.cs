using e_potreba.Domain.Entity.Common;
using e_potreba.Domain.Enum;

namespace e_potreba.Domain.Entity;
public class User: BaseEntity 
{
    public required string Login{ get; set; }
    public required string HashPassword{ get; set; }
    public required string Email{ get; set; }
    public bool IsEmailConfirmed { get; set; } = false;
    public required UserRole Role { get; set; } = UserRole.common;
}
