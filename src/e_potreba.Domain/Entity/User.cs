using e_potreba.Domain.Entity.Common;
using e_potreba.Domain.Enum;

namespace e_potreba.Domain.Entity;
public class User: BaseEntity 
{
    public required string Login;
    public required string HashPassword;
    public required string Email;
    public bool IsEmailConfirmed = false;
    public required UserRole Role = UserRole.common;
}
