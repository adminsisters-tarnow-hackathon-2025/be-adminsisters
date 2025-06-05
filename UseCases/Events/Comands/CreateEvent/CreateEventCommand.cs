using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Events.Comands.CreateEvent;

public record CreateEventOptions(
    string Name,
    string ShortDescription,
    string LongDescription,
    decimal Price,
    int CoinReward,
    byte[] Image,
    string Type,
    List<string> Tags,
    DateTime DateFrom,
    DateTime DateTo,
    Guid LocationId);

public record CreateEventCommand(Guid Id, CreateEventOptions Options) : IRequest<ResponseWrapper<Guid>>;