using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Events.Queries.GetEvent;

public record GetEventQuery(Guid Id): IRequest<ResponseWrapper<EventDto>>;
