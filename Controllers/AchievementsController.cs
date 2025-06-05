using be_adminsisters.UseCases.Achievements.Commands.CreateAchievement;
using be_adminsisters.UseCases.Achievements.Commands.UpdateAchievement;
using be_adminsisters.UseCases.Achievements.Queries.GetAchievement;
using be_adminsisters.UseCases.Achievements.Queries.GetAchievements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace be_adminsisters.Controllers;

[Route("api/achievements")]
public class AchievementsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAchievements()
    {
        var query = new GetAchievementsQuery();
        var result = mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetAchievement(Guid id)
    {
        var query = new GetAchievementQuery(id);
        var result = mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAchievement([FromBody] CreateAchievementCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAchievement(Guid id, [FromBody] UpdateAchievementOptions options )
    {
        var command = new UpdateAchievementCommand(id, options);
        await mediator.Send(command);
        return Ok();
    }
}