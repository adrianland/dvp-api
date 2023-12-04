using DVP.Project.Domain.Models;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.Domain.AggregatesModel.PersonAggregate;

public interface IPersonFinder : IFinder<PersonDto, string>
{
    Task<IList<PersonDto>> GetPersonById(int id);
    Task<IList<PersonDto>> GetPersons();
    Task<int> CountAllPersons();
}
