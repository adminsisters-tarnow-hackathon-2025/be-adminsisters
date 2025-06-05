using AdminSisters.Api.UseCases.Users.Commands;
using AdminSisters.Api.UseCases.Users.Commands.CreateUser;
using AdminSisters.Api.UseCases.Users.Commands.DeleteUser;
using AdminSisters.Api.UseCases.Users.Queries.GetUser;
using AdminSisters.Api.UseCases.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AdminSisters.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await mediator.Send(new GetUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await mediator.Send(new GetUserQuery(id));
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var userId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUser), new { id = userId }, null);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await mediator.Send(new DeleteUserCommand(id));
        return NoContent();
    }
}