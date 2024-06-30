using Ardalis.ApiEndpoints;
using e_potreba.Application.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace e_potreba.API.Endpoints.UserEndpoints;

[Route("api/v1/users")]
public class GetAllUsersEndpoint : EndpointBaseSync
    .WithoutRequest
    .WithActionResult<List<UserResponse>>
{
    [HttpGet]
    public override ActionResult<List<UserResponse>> Handle()
    {
        return Ok();
    }
}
