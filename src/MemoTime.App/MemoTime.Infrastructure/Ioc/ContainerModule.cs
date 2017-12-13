using Autofac;
using MemoTime.Infrastructure.Ioc.Modules;

namespace MemoTime.Infrastructure.Ioc
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();
        }   
    }
}