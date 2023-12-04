using Autofac;
using DVP.Project.AggregatesModel.PersonAggregate;
using DVP.Project.AggregatesModel.UserAggregate;
using DVP.Project.Domain.AggregatesModel.PersonAggregate;
using DVP.Project.Domain.Infrastructure.Repository;
using DVP.Project.Infrastructure.Finder.Person;

namespace DVP.Project.Api.Infrastructure.AutofactModules;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        builder.Register(ctx => new HttpClient())
           .SingleInstance();

        builder.RegisterType<PersonFinder>()
        .As<IPersonFinder>()
        .InstancePerLifetimeScope();

        builder.RegisterType<PersonRepository>()
           .As<IPersonRepository>()
        .InstancePerLifetimeScope();

        builder.RegisterType<UserRepository>()
           .As<IUserRepository>()
        .InstancePerLifetimeScope();

    }
}