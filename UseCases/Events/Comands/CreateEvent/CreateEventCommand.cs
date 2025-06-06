using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Events.Comands.CreateEvent;

public record CreateEventCommand(
    string Name,
    string ShortDescription,
    string LongDescription,
    decimal Price,
    int CoinReward,
    string Type,
    List<string> Tags,
    DateTime DateFrom,
    DateTime DateTo,
    byte[] Image,
    Guid LocationId) : IRequest<ResponseWrapper<Guid>>;