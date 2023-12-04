using DVP.Project.AggregatesModel.PersonAggregate;
using DVP.Project.Api.Application.Commands.Person;
using DVP.Project.Domain.AggregatesModel;
using MediatR;


public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
{
    private readonly IPersonRepository _iPersonRepository;


    public CreatePersonCommandHandler(IPersonRepository iPersonRepository)
    {
        _iPersonRepository = iPersonRepository;
    }

    public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var newPerson = new Person(request.Name, request.LastName, request.DocumentNumber,request.DocumentType, request.Email);

        Console.WriteLine(newPerson);
        _iPersonRepository.Add(newPerson);

        var saveOK = await _iPersonRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return saveOK;
    }
}