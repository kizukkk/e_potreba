using e_potreba.Application.Abstractions;
using e_potreba.Application.Repositories;

namespace e_potreba.Application.Service.AuthServices;
public class UserRegistryService
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider _jwtProvider;


    public UserRegistryService(IUserRepository userRepo, IJwtProvider jwtProvider)
    {
        _userRepo = userRepo;
        _jwtProvider = jwtProvider;
    }


    
}
