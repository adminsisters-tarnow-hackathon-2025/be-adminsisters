using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Locations.Commands.CreateLocation;

public record CreateLocationCommand(
    string Name,
    string Address,
    double Longitude,
    double Latitude
) : IRequest<ResponseWrapper<Guid>>;
