using be_adminsisters.UseCases.Events.Comands.CreateEvent;
using MediatR;

namespace be_adminsisters.UseCases.Events.Comands.UpdateEvent;

public record UpdateEventOptions(
    string? Name,
    string? ShortDescription,
    string? LongDescription,
    decimal? Price,
    int? CoinReward,
    byte[]? Image,
    string? Type,
    List<string>? Tags,
    DateTime? DateFrom,
    DateTime? DateTo,
    Guid? LocationId);

public record UpdateEventCommand(Guid Id, UpdateEventOptions Options) : IRequest;