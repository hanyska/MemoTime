using Autofac;
using AutoMapper;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Mappers;
using MemoTime.Infrastructure.Services;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Ioc.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfiguration.Initialize())
                .As<IMapper>()
                .SingleInstance();
            
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProjectService>()
                .As<IProjectService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TaskService>()
                .As<ITaskService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LabelService>()
                .As<ILabelService>()
                .InstancePerLifetimeScope();
        }
    }
}