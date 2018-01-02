using Microsoft.AspNetCore.Builder;

namespace Common.DeveloperTools.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerForApi(this IApplicationBuilder app, string apiName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", apiName);
            });


            return app;
        }
    }
}
