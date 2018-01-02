using Common.Extensions.Startup;
using MainApi.Api.Formatting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using ModelContract.Dto;
using ModelContract.Exceptions;
using System;
using System.Net;

namespace MainApi.Api.Filters
{
    public class ApiCustomExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _environment;

        public ApiCustomExceptionFilter(IHostingEnvironment env)
        {
            _environment = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (IsCustomException(context.Exception))
            {
                MainApiException exception = (MainApiException)context.Exception;
                context.ExceptionHandled = true;
                context.Result = CreateApiResultFromException(exception);
            }
        }

        private ApiResult CreateApiResultFromException(MainApiException exception)
        {
            Error error = new Error();
            if (!_environment.IsProdEnvironment())
            {
                error.Message = exception.Message;
                error.ExtraInfo = exception.StackTrace;
            }

            ApiResult apiResult = new ApiResult(error, HttpStatusCode.InternalServerError);

            return apiResult;
        }

        private bool IsCustomException(Exception exception)
        {
            return exception is MainApiException;
        }
    }
}
