using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Common.Models;
using AdminSisters.Api.Persistence.Entities;
using MediatR;

namespace AdminSisters.Api.UseCases.Users.Commands.CreateUser;

public class CreateUserHandler(IRepository repository) : IRequestHandler<CreateUserCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Name,request.Password);
        
        repository.Users.Add(user);
        await repository.SaveChangesAsync(cancellationToken);
        
        return new ResponseWrapper<Guid>(){ Data = user.Id};
    }
}