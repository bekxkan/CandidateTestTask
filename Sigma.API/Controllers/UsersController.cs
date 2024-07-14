using Mapster;
using Microsoft.AspNetCore.Mvc;
using Sigma.API.Controllers.Requests;
using Sigma.API.Controllers.Responses;
using Sigma.Services.Users;
using Sigma.Services.Users.Models;

namespace Sigma.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    [HttpPost(Name = "CreateUpdateUser")]
    public async Task<IActionResult> CreateUpdateUserAsync([FromBody] CreateUpdateUserRequest user)
    {
        var result = await _service.CreateUpdateUserAsync(user.Adapt<CreateUpdateUserDto>());
        return Ok(result.Adapt<CreateUpdateUserResponse>());
    }
}
