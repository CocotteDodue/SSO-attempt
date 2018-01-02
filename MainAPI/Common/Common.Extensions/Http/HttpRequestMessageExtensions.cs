using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Common.Extensions.Http
{
    public static class HttpRequestMessageExtensions
    {
        public static HttpRequestMessage InitialiseGet(this HttpRequestMessage request, Uri uri)
        {
            request.AddMethod(HttpMethod.Get)
                .AddHeaderAccept()
                .AddUri(uri);

            return request;
        }

        public static HttpRequestMessage InitialisePost<T>(this HttpRequestMessage request, Uri uri, T content)
        {
            request.AddMethod(HttpMethod.Post)
                .AddHeaderAccept()
                .AddUri(uri)
                .AddContent(content);

            return request;
        }

        public static HttpRequestMessage AddMethod(this HttpRequestMessage request, HttpMethod method)
        {
            request.Method = method;
            return request;
        }
        public static HttpRequestMessage AddUri(this HttpRequestMessage request, Uri uri)
        {
            request.RequestUri = uri;
            return request;
        }
        public static HttpRequestMessage AddContent<T>(this HttpRequestMessage request, T contentObject)
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(contentObject), Encoding.UTF8, "application/json");
            return request;
        }
        public static HttpRequestMessage AddHeaderAccept(this HttpRequestMessage request)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return request;
        }
    }
}
