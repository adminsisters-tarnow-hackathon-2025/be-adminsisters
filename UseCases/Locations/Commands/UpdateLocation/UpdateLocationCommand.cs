using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Locations.Commands.UpdateLocation;

public record UpdateLocationOptions(
    string Name,
    string Address,
    double Longitude,
    double Latitude
);
public record UpdateLocationCommand(
  Guid Id,
  UpdateLocationOptions Options
) : IRequest<ResponseWrapper<Guid>>;
