using be_adminsisters.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Commands.DeleteUser;

public class DeleteUserHandler(IRepository repository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException("Nie znaleziono podanego użytkownika!");
        repository.Users.Remove(user);
        await repository.SaveChangesAsync(cancellationToken);
    }
}