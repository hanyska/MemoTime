using Autofac;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Repositories;

namespace MemoTime.Infrastructure.Ioc.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<InMemoryProjectRepository>()
                .As<IProjectRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InMemoryTaskRepository>()
                .As<ITaskRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SqlLabelRepository>()
                .As<ILabelRepository>()
                .InstancePerLifetimeScope();
        }        
    }
}