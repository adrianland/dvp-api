using DVP.Project.Domain.AggregatesModel.PersonAggregate;
using DVP.Project.Domain.Models;
using MediatR;

namespace DVP.Project.Api.Application.Queries.Person
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IList<PersonDto>>
    {

        private readonly IPersonFinder _iPersonFinder;

        public GetPersonsQueryHandler(IPersonFinder currencyFinder)
        {
            _iPersonFinder = currencyFinder;
        }

        public async Task<IList<PersonDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _iPersonFinder.GetPersons();
        }
    }
}
