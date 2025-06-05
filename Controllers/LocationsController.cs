using be_adminsisters.UseCases.Locations.Commands.CreateLocation;
using be_adminsisters.UseCases.Locations.Commands.DeleteLocation;
using be_adminsisters.UseCases.Locations.Commands.UpdateLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace be_adminsisters.Controllers;

[Route("api/locations")]
public class LocationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
    {
        var locationId = await mediator.Send(command);
        return Ok(locationId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand command)
    {
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