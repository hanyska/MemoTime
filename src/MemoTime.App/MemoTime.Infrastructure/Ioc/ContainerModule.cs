using Autofac;
using MemoTime.Infrastructure.Ioc.Modules;
using Microsoft.Extensions.Configuration;

namespace MemoTime.Infrastructure.Ioc
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
//            builder.RegisterModule<MongoModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
        }   
    }
}