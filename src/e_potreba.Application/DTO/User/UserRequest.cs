namespace e_potreba.Application.DTO.User;
public sealed record UserRequest(
    string login, string email, string password
    )
{
}
