using Autofac;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Repositories;

namespace MemoTime.Infrastructure.Ioc.Modules
{
    public class SqlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlUserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<SqlProjectRepository>()
                .As<IProjectRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<SqlTaskRepository>()
                .As<ITaskRepository>()
                .InstancePerLifetimeScope();
        }
    }
}