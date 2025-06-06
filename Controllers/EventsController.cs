using be_adminsisters.UseCases.Events.Comands.CreateEvent;
using be_adminsisters.UseCases.Events.Comands.UpdateEvent;
using be_adminsisters.UseCases.Events.Queries.GetEvent;
using be_adminsisters.UseCases.Events.Queries.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace be_adminsisters.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        var query = new GetEventsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEvent(Guid id)
    {
        var query = new GetEventQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody]  CreateEventCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEvent(Guid id, UpdateEventOptions options)
    {
        var command = new UpdateEventCommand(id, options);
        await mediator.Send(command);
        return Ok();
    }
}