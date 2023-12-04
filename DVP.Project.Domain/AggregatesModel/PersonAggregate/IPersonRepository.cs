using DVP.Project.Domain.AggregatesModel;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.AggregatesModel.PersonAggregate;

public interface IPersonRepository : IRepository<Person>
{
    Person Add(Person person);
    void Update(Person person);
    void Delete(int personId); 
    Task<Person> GetPersonById(int personId);
}