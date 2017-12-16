using System;
using Autofac;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace MemoTime.Infrastructure.Ioc.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
        }
    }
}