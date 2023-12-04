using DVP.Project.AggregatesModel.PersonAggregate;
using DVP.Project.Api.Application.Commands.Person;
using DVP.Project.Domain.Exception;
using MediatR;


public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
{
    private readonly IPersonRepository _iPersonRepository;


    public UpdatePersonCommandHandler(IPersonRepository iPersonRepository)
    {
        _iPersonRepository = iPersonRepository;
    }

    public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var dbPerson = await _iPersonRepository.GetPersonById(request.Id);

        if (dbPerson != null)
        {
            dbPerson.Name = request.Name;
            dbPerson.LastName = request.LastName;
            dbPerson.DocumentNumber = request.DocumentNumber;
            dbPerson.DocumentType = request.DocumentType;
            dbPerson.Email = request.Email;
            dbPerson.FullName = request.Name + " " + request.LastName;
            dbPerson.FullDocument = request.DocumentType + " " + request.DocumentNumber;
            dbPerson.UpdatedAt = DateTime.Now;

            _iPersonRepository.Update(dbPerson);
            return await _iPersonRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        throw new EntityNotFoundException();

    }
}