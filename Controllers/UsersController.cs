using be_adminsisters.UseCases.Users.Commands.AddCoinToUser;
using be_adminsisters.UseCases.Users.Commands.AssignUserToEvent;
using be_adminsisters.UseCases.Users.Commands.CreateUser;
using be_adminsisters.UseCases.Users.Commands.DeleteUser;
using be_adminsisters.UseCases.Users.Commands.LoginUser;
using be_adminsisters.UseCases.Users.Commands.SubtractionCoinToUser;
using be_adminsisters.UseCases.Users.Queries.GetUser;
using be_adminsisters.UseCases.Users.Queries.GetUserEvents;
using be_adminsisters.UseCases.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace be_adminsisters.Controllers;

[Route("api/users")]
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

    [HttpGet("{id:guid}/events")]
    public async Task<IActionResult> GetUserEvents(Guid id)
    {
        var user = await mediator.Send(new GetUserEventsQuery(id));
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var userId = await mediator.Send(command);
        return Ok(userId);
    }

    [HttpPost("{id:guid}/add-coin")]
    public async Task<IActionResult> AddCoinToUser(Guid id, [FromBody] AddCoinToUserOptions options)
    {
        var command = new AddCoinToUserCommand(id, options);
        var newCoinBalance = await mediator.Send(command);
        return Ok(newCoinBalance);
    }

    [HttpPost("{userId:guid}/events/{eventId:guid}")]
    public async Task<IActionResult> AssignUserToEvent(Guid userId, Guid eventId)
    {
        var command = new AssignUserToEventCommand(userId, eventId);
        await mediator.Send(command);
        return Ok();
    }

    
    [HttpPost("{id:guid}/subtraction-coin")]
    public async Task<IActionResult> RemoveCoinToUser(Guid id, [FromBody] RemoveCoinToUserOptions options)
    {
        var command = new SubtractionCoinToUserCommand(id, options);
        var newCoinBalance = await mediator.Send(command);
        return Ok(newCoinBalance);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
    {
        var userId = await mediator.Send(command);
        return Ok(userId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await mediator.Send(new DeleteUserCommand(id));
        return NoContent();
    }
}