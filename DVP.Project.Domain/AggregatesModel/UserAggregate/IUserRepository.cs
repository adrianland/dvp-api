using DVP.Project.Domain.AggregatesModel.UserAggregate;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.AggregatesModel.UserAggregate;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);
    Task<User> GetUserById(string userName, string password);
}