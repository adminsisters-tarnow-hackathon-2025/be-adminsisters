using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.Persistence.Entities;
using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.CreateUser;

public class CreateUserHandler(IRepository repository) : IRequestHandler<CreateUserCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Name,request.Password);
        
        await repository.Users.AddAsync(user, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        
        return new ResponseWrapper<Guid>(){ Data = user.Id};
    }
}