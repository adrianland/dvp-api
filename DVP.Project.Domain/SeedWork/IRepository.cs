namespace DVP.Project.Domain.SeedWork;

public interface IRepository<T>
{
    IUnitOfWork UnitOfWork { get; }
}
