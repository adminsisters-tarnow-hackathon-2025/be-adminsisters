using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.SubtractionCoinToUser;

public record RemoveCoinToUserOptions(int Amount);
public record SubtractionCoinToUserCommand(Guid Id, RemoveCoinToUserOptions Options) : IRequest<ResponseWrapper<int>>;