using MainApi.Api.Formatting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelContract.Dto;
using System.Linq;
using System.Net;

namespace MainApi.Api.Filters
{
    public class ModelValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Error error = new Error { Message = "Model has invalid Properties" };
                
                error.ExtraInfo = context.ModelState
                    .Where(p => p.Value.ValidationState == ModelValidationState.Invalid)
                    .Select(invalidProp => new { PropertyName = invalidProp.Key, InvalidValue = invalidProp.Value.RawValue })
                    .ToArray();

                ApiResult result = new ApiResult(error, HttpStatusCode.BadRequest);
                context.Result = result;
            }
        }

        private bool IsResultFormatted(IActionResult result)
        {
            return result is ApiResult;
        }

        private ApiResult FormatApiResult(ActionExecutedContext context)
        {
            ApiResult formattedResult = new ApiResult(context.Result);

            return formattedResult;
        }
    }
}
