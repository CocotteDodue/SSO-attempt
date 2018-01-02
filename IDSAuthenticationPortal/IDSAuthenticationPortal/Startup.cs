using GruntifyV4.Common.Extensions.Startup;
using GruntifyV4.Logic.Billing;
using GruntifyV4.Logic.SignUp;
using GruntifyV4.Model.Master.Contract;
using GruntifyV4.Model.Master.Contract.Entities;
using GruntifyV4.Model.Master.Contract.Interfaces.BusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using System.Reflection;

namespace IDSAuthenticationPortal
{
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
            
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCors("AllowAllOrigins");
        }
    }
}
