using Autofac;
using Banking.DotNetConf.Core.Interfaces;
using Banking.DotNetConf.Core.Services;

namespace Banking.DotNetConf.Core;

public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ToDoItemSearchService>()
            .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    }
}
