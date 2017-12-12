using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MemoTime.Api.Framework;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Ioc;
using MemoTime.Infrastructure.Repositories;
using MemoTime.Infrastructure.Services;
using MemoTime.Infrastructure.Services.Interfaces;
using MemoTime.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MemoTime.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtSettings = Configuration.GetSection("jwt").Get<JwtSettings>();
            var mongoSettings = Configuration.GetSection("mongo").Get<MongoSettings>(); //it doesn't

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.ValidIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ValidateAudience = false
                    };
                });
            services.AddCors(o => o.AddPolicy("MyPolicy", b =>
            {
                b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddMvc();

            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule());
            ApplicationContainer = builder.Build();

        }                                                                                                                

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            MongoConfigurator.Initialize();
            
            app.UseCors("MyPolicy");
            app.UserErrorHandlerMiddleware();
            app.UseAuthentication();
            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}