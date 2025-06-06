using be_adminsisters.UseCases.Locations.Commands.CreateLocation;
using be_adminsisters.UseCases.Locations.Commands.DeleteLocation;
using be_adminsisters.UseCases.Locations.Commands.UpdateLocation;
using be_adminsisters.UseCases.Locations.Queries.GetLocations;
using be_adminsisters.UseCases.Locations.Queries.GetLocationsWithEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace be_adminsisters.Controllers;

[Route("api/locations")]
public class LocationsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var users = await mediator.Send(new GetLocationsQuery());
        return Ok(users);
    }
    
    [HttpGet("events")]
    public async Task<IActionResult> GetLocationsWithEvents()
    {
        var locations = await mediator.Send(new GetLocationsWithEventsQuery());
        return Ok(locations);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
    {
        var locationId = await mediator.Send(command);
        return Ok(locationId);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateLocation(Guid id, [FromBody] UpdateLocationOptions updateLocationOptions)
    {
        var command = new UpdateLocationCommand(id, updateLocationOptions);

        var locationId = await mediator.Send(command);
        return Ok(locationId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLocation(Guid id)
    {
        await mediator.Send(new DeleteLocationCommand(id));
        return NoContent();
    }
}