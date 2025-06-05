using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.AddCoinToUser;

public record AddCoinToUserOptions(int Amount);
public record AddCoinToUserCommand(Guid Id, AddCoinToUserOptions Options) : IRequest<ResponseWrapper<int>>;