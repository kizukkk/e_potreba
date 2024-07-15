using e_potreba.Application.Abstractions;
using e_potreba.Application.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace e_potreba.Application.Service.AuthServices;
public class UserRegistryService
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider _jwtProvider;
    private readonly ResiliencePipeline _resiliencePipeline;


    public UserRegistryService(
        IUserRepository userRepo, 
        IJwtProvider jwtProvider,
        [FromKeyedServices("default-pipeline")]
        ResiliencePipeline pipeline
        )
    {
        _userRepo = userRepo;
        _jwtProvider = jwtProvider;
        _resiliencePipeline = pipeline;
    }

    public async Task Execute(CancellationToken token)
    {
        throw new NotImplementedException();
    }


    
}
