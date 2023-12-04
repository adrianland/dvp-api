using DVP.Project.AggregatesModel.PersonAggregate;
using DVP.Project.Api.Application.Commands.Person;
using DVP.Project.Domain.AggregatesModel;
using MediatR;


public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IPersonRepository _iPersonRepository;


    public DeletePersonCommandHandler(IPersonRepository iPersonRepository)
    {
        _iPersonRepository = iPersonRepository;
    }

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {

        _iPersonRepository.Delete(request.Id);

        var saveOK = await _iPersonRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return saveOK;
    }
}