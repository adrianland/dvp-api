using System.Linq;
using DVP.Project.AggregatesModel.PersonAggregate;
using DVP.Project.Domain.AggregatesModel;
using DVP.Project.Domain.Models;
using DVP.Project.Domain.SeedWork;
using DVP.Project.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NBitcoin.Secp256k1;

namespace DVP.Project.Domain.Infrastructure.Repository;

public class PersonRepository : IPersonRepository
{

    private readonly DVPContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public PersonRepository(DVPContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Person Add(Person person)
    {
        return _context.Persons.Add(person).Entity;
    }

    public void Update(Person person)
    {
        _context.Entry(person).State = EntityState.Modified;
    }

    public async Task<Person> GetPersonById(int personId)
    {
        var person = await _context
            .Persons
            .FirstOrDefaultAsync(u => u.Id == personId);

        return person;
    }

    public  void Delete(int personId)
    {

        var person = _context.Persons.SingleOrDefault(x => x.Id == personId); 

        if (person != null)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }

}