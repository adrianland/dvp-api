using MediatR;
using DVP.Project.Domain.Models;

namespace DVP.Project.Api.Application.Queries.Person
{
    public class GetPersonsQuery : IRequest<IList<PersonDto>>
    {


    }
}
