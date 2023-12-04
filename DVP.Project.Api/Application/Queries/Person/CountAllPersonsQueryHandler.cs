using DVP.Project.Domain.AggregatesModel.PersonAggregate;
using DVP.Project.Domain.Models;
using MediatR;

namespace DVP.Project.Api.Application.Queries.Person
{
    public class CountAllPersonsQueryHandler : IRequestHandler<CountAllPersonsQuery, int>
    {

        private readonly IPersonFinder _iPersonFinder;

        public CountAllPersonsQueryHandler(IPersonFinder currencyFinder)
        {
            _iPersonFinder = currencyFinder;
        }

        public async Task<int> Handle(CountAllPersonsQuery request, CancellationToken cancellationToken)
        {
           var count = await _iPersonFinder.CountAllPersons();
            return count;
        }
    }
}
