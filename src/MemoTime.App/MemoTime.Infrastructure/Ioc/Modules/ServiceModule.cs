using Autofac;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Services;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Ioc.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
        
    }
}