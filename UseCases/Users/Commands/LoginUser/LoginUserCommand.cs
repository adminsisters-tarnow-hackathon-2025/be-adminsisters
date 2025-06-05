using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.LoginUser;

public record LoginUserCommand(string Name, string Password) : IRequest<ResponseWrapper<Guid>>;