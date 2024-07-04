using Ardalis.ApiEndpoints;
using e_potreba.Application.DTO.Auth;
using e_potreba.Application.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace e_potreba.API.Endpoints.UserEndpoints;

[Route("api/v1/users/registry")]
public class RegistryUserEndpoint : EndpointBaseSync
    .WithRequest<UserRequest>
    .WithActionResult<AuthUserResponse>
{
    [HttpPost]
    public override ActionResult<AuthUserResponse> Handle(
        [FromBody] UserRequest request
        )
    {
        return Ok();
    }
}
