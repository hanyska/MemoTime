using System;
using Autofac;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Repositories;
using MemoTime.Infrastructure.Settings;
using MongoDB.Driver;

namespace MemoTime.Infrastructure.Ioc.Modules
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            var settings = new MongoSettings  //dodac wstrzykiwanie ustawien
            {
                Connection = "mongodb://localhost:27017",
                Database = "MemoTime"
            };

            builder.RegisterInstance(new MongoClient(settings.Connection))
                .SingleInstance();

            builder.Register((c, p) =>
            {
                var mongoClient = c.Resolve<MongoClient>();
                var database = mongoClient.GetDatabase(settings.Database);
                return database;
            }).As<IMongoDatabase>();

            builder.RegisterType<MongoUserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            Console.WriteLine("asdasd");
        }
    }
}