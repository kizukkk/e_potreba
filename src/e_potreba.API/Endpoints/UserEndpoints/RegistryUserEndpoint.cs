using Ardalis.ApiEndpoints;
using e_potreba.Application.DTO.Auth;
using e_potreba.Application.DTO.User;
using e_potreba.Application.Service.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace e_potreba.API.Endpoints.UserEndpoints;

[Route("api/v1/users/registry")]
public class RegistryUserEndpoint : EndpointBaseAsync
    .WithRequest<UserRequest>
    .WithActionResult<AuthUserResponse>
{

    private readonly UserRegistryService _service;
    public RegistryUserEndpoint(UserRegistryService service)
    {
        _service = service;
    }


    [HttpPost]
    public override async Task<ActionResult<AuthUserResponse>> HandleAsync(
        UserRequest request, 
        CancellationToken cancellationToken = default
        )
    {
        await _service.Execute(cancellationToken);
        return Ok();
    }
}
