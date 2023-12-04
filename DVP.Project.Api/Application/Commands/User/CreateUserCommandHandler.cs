using DVP.Project.AggregatesModel.UserAggregate;
using DVP.Project.Api.Application.Commands.User;
using DVP.Project.Domain.AggregatesModel.UserAggregate;
using MediatR;


public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUserRepository _iUsernRepository;


    public CreateUserCommandHandler(IUserRepository iUserRepository)
    {
        _iUsernRepository = iUserRepository;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User(request.Username, request.Password);

        Console.WriteLine(newUser);
        _iUsernRepository.Add(newUser);

        var saveOK = await _iUsernRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return saveOK;
    }
}