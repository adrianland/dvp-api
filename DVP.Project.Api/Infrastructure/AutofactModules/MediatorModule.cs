using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace DVP.Project.Api.Infrastructure.AutofactModules;

public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Parte de esto lo podemos ignorar si registramos con IServiceCollection.AddMediatR(...)
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        var services = new ServiceCollection();

        builder.Populate(services);
    }
}