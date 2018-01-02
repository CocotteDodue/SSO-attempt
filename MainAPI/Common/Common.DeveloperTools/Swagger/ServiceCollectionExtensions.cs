using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Common.DeveloperTools.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger (this IServiceCollection services, string swaggerApiTitle)
        {
            var swaggerDocInfo = new Info
            {
                Version = "v1",
                Title = swaggerApiTitle
            };

            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", swaggerDocInfo);
                c.CustomSchemaIds(t => t.FullName);
            });
        }
    }
}
