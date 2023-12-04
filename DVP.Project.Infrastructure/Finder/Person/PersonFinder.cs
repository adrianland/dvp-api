using Dapper;
using DVP.Project.Domain.AggregatesModel.PersonAggregate;
using DVP.Project.Domain.Exception;
using DVP.Project.Domain.Models;
using DVP.Project.Infrastructure.Finder.Util;
using System.Data;

namespace DVP.Project.Infrastructure.Finder.Person;

public class PersonFinder : IPersonFinder
{
    private readonly IDbConnection _connection;

    public PersonFinder(IDbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public Task<PersonDto> FindByIdAsync(string id)
    {
        throw new NotImplementedException();
    }


    public async Task<IList<PersonDto>> GetPersons()
    {

        var sql = SQLReader.GetQuery("get-all-persons").Result;
        var dictionary = new Dictionary<string, object>
        {

        };

        var parameters = new DynamicParameters(dictionary);

        var persons = await _connection.QueryAsync<PersonDto>(sql, parameters);

        if (persons is null) throw new BadRequestException($"there are no system parameters.");

        return persons.ToList();
    }

    public async Task<IList<PersonDto>> GetPersonById(int id)
    {

        var sql = SQLReader.GetQuery("get-all-persons").Result;
        var dictionary = new Dictionary<string, object>
        {
              { "@id", id },
        };

        var parameters = new DynamicParameters(dictionary);

        var persons = await _connection.QueryAsync<PersonDto>(sql, parameters);

        if (persons is null) throw new BadRequestException($"there are no system parameters.");

        return persons.ToList();
    }

    public async Task<int> CountAllPersons()
    {

        var sql = SQLReader.GetQuery("count-all-persons").Result;
        var dictionary = new Dictionary<string, object>
        {
        };

        var parameters = new DynamicParameters(dictionary);

        var count = await  _connection.QuerySingleAsync(sql, parameters);

        if (count is null) throw new BadRequestException($"there are no system parameters.");

        return count.count_all_persons;
    }


}