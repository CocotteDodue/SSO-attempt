using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelContract.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace MainApi.Api.Formatting
{
    [JsonConverter(typeof(ApiResultJsonConverter))]
    public class ApiResult : JsonResult
    {
        public bool Success { get; set; }

        public object Result => this.Value;

        public Error Error => this.Value is Error ? (Error)this.Value : null;
        
        public int CustomStatusCode => StatusCode.Value;
        
        public ApiResult(object value, HttpStatusCode statusCode)
            : base(value)
        {
            StatusCode = (int)statusCode;
            DeduceSuccessValueType();
            ContentType = "application/json";
        }

        public ApiResult(object value) 
            : this(value, HttpStatusCode.OK)
        { }

        public ApiResult(object value, HttpStatusCode statusCode, bool success) 
            : this(value, statusCode)
        {
            Success = success;
        }

        public ApiResult(object value, JsonSerializerSettings serializerSettings) 
            : this(value)
        {
            SerializerSettings = serializerSettings;
        }

        public async override Task ExecuteResultAsync(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;

            response.ContentType = ContentType;
            response.StatusCode = CustomStatusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(this));
        }

        private void DeduceSuccessValueType()
        {
            Success = !(Value is Error);
        }
    }
}
