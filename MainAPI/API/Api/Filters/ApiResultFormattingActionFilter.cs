using MainApi.Api.Formatting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MainApi.Api.Filters
{
    public class ApiResultFormattingActionFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (!isResultFormatted(context.Result))
            {
                context.Result = FormatApiResult(context);
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        { }

        private bool isResultFormatted(IActionResult result)
        {
            return result is ApiResult;
        }

        private ApiResult FormatApiResult(ResultExecutingContext context)
        {
            ApiResult formattedResult = new ApiResult(((ObjectResult)context.Result).Value);

            return formattedResult;
        }
    }
}
