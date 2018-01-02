using Business;
using Common.DeveloperTools.DataInitialization;
using Common.DeveloperTools.Swagger;
using Common.Extensions.Startup;
using MainApi.Api.Filters;
using MainApi.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelContract;
using ModelContract.Entities;
using System.Reflection;

namespace MainApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                })
            ); 

            services.AddAutoMapper(typeof(EntityBase).GetTypeInfo().Assembly);

            var connection = Configuration.GetConnectionString("MasterDb");
            services.AddScoped(x => new MainApiDbContextInstance(connection));

            services.AddScoped<CvFacade>();
            services.AddScoped<UserFacade>();

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ModelValidationFilter));
                opt.Filters.Add(typeof(ApiCustomExceptionFilter));
                opt.Filters.Add(typeof(ApiResultFormattingActionFilter));
            });
            
            services.AddSwagger("Sign up Services API");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new UnhandledErrorMiddleware(env).Invoke
            });

            // TODO: setup azure build to use Development on QA env
            if (!env.IsProdEnvironment())
            {
                app.UseSwaggerForApi("Sign up");
                app.SeedDatabase(Configuration);
            }

            app.UseCors("AllowAllOrigins");
            
            app.UseMvc();
        }
    }
}
