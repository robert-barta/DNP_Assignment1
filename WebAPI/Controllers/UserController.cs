using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;

namespace WebAPI;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly IUserLogic UserLogic;

    public UserController(IUserLogic userLogic)
    {
        UserLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
    {
        try
        {
            User user = await UserLogic.CreateAsync(dto);
            return Created($"/users/{user.Id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}