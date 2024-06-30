using e_potreba.Domain.Enum;

namespace e_potreba.Application.DTO.User;
public sealed record UserResponse(
    Guid id, string login, string email, UserRole role
    )
{
}
