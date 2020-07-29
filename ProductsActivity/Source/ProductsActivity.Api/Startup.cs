using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using APIBase.Api.Configurations;
using APIBase.Common.AuthFunctions;
using APIBase.Common.Constants;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductsActivity.Bll.Blls.ImageLikeBll;
using ProductsActivity.Common.Settings;
using ProductsActivity.Dal.Contexts;
using ProductsActivity.Dal.Repositories.ImageLikeRepository;

namespace ProductsActivity.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext to Migrations
            var connectionString = Configuration.GetConnectionString("ProductsActivityConnectionString");
            services.AddDbContextPool<ProductsActivityContext>(options =>
            {
                options.UseNpgsql(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });

            //Configure Auto mapper
            var assemblies = new List<Assembly>
            {
                typeof(ImageLikeRepository).Module.Assembly,
                typeof(ImageLikeBll).Module.Assembly,
                typeof(Startup).Module.Assembly
            };
            services.AddAutoMapper(assemblies);
            
            services.AddOptions();

            //Configure settings from appsettings
            services.Configure<ProductsActivitySettings>(Configuration);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            AddAutoFacRegistration(builder);

            var container = builder.Build();

            //Configure Authentication
            services.ConfigureAuthentication<ProductsActivitySettings>(container, "tempkey.rsa");

            //Configure Cors allowed
            services.ConfigureCors<ProductsActivitySettings>(container, "GET", "POST", "PUT");

            //Configure HealthChecks
            services.AddHealthChecks();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddAutoFacRegistration(builder);
        }

        public void AddAutoFacRegistration(ContainerBuilder builder)
        {
            #region Api

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            #endregion
            
            #region Bll

            builder.RegisterAssemblyTypes(typeof(ImageLikeBll).Module.Assembly).AsImplementedInterfaces();

            #endregion

            #region Dal

            //Register Contexts
            builder.Register(ctx =>
            {
                var connectionString = ctx.Resolve<ProductsActivitySettings>().ConnectionStrings.ProductsActivityConnectionString;
                var dbOptions = new DbContextOptionsBuilder<ProductsActivityContext>().UseNpgsql(connectionString, opt =>
                    {
                        opt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    }).Options;
                return dbOptions;
            }).InstancePerDependency();

            builder.Register(ctx =>
            {
                var connectionString = ctx.Resolve<ProductsActivitySettings>().ConnectionStrings.CatalogueConnectionString;
                var dbOptions = new DbContextOptionsBuilder<CatalogueContext>().UseNpgsql(connectionString, opt =>
                    {
                        opt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    }).Options;
                return dbOptions;
            }).InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(ImageLikeRepository).Module.Assembly).AsImplementedInterfaces();

            #endregion

            #region Common

            //Register settings from appsettings
            builder.Register(ctx =>
            {
                var options = ctx.Resolve<IOptions<ProductsActivitySettings>>();
                return options.Value;
            }).InstancePerLifetimeScope();

            //Register TokenFunctions
            builder.RegisterType<TokenFunctions>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<HttpContextAccessor>().AsImplementedInterfaces().InstancePerDependency();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(BaseConstants.ALLOWED_CORS_POLICY);

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseHealthChecks("/HealthChecks");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
