using System.Linq;
using DVP.Project.AggregatesModel.UserAggregate;
using DVP.Project.Domain.AggregatesModel.UserAggregate;
using DVP.Project.Domain.SeedWork;
using DVP.Project.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DVP.Project.Domain.Infrastructure.Repository;

public class UserRepository : IUserRepository
{

    private readonly DVPContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public UserRepository(DVPContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public User Add(User user)
    {
        return _context.Users.Add(user).Entity;
    }

    public async Task<User> GetUserById(string userName, string password)
    {
        var user = await _context
            .Users
            .FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);

        return user;
    }
}