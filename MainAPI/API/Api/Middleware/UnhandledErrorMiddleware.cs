using Common.Extensions.Startup;
using MainApi.Api.Formatting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ModelContract.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace MainApi.Api.Middleware
{
    public class UnhandledErrorMiddleware
    {
        private IHostingEnvironment _env;

        public UnhandledErrorMiddleware(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            Error error = new Error();

            if (ex != null)
            { 
                error.Message = _env.IsProdEnvironment() 
                    ? "Oops something happend on Server" 
                    : ex.Error.InnerException?.Message ?? ex.Error.Message;

                if (!_env.IsProdEnvironment())
                {
                    error.ExtraInfo = new { StackTrace = ex.Error.StackTrace };
                }
            }

            ApiResult result = new ApiResult(error, HttpStatusCode.InternalServerError);
            context.Response.StatusCode = result.CustomStatusCode;
            context.Response.ContentType = result.ContentType;
            
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
