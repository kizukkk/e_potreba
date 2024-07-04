using e_potreba.Domain.Enum;

namespace e_potreba.Application.DTO.Auth;
public sealed record AuthUserResponse(
    Guid id, 
    string login, 
    string email, 
    UserRole role,
    string token
    )
{
}
