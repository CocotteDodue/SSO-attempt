using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace MainApi.Api.Formatting
{
    public class ApiResultJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ApiResult result = (ApiResult)value;

            serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            if (value != null)
            {
                Type apiResultType = result.GetType();
                writer.WriteStartObject();
                SerializePropertyFromApiResult(nameof(ApiResult.Success),writer, serializer, result, apiResultType);

                if (!result.Success
                    && result.Error != null)
                {
                    SerializePropertyFromApiResult(nameof(ApiResult.Error), writer, serializer, result, apiResultType);
                }
                else
                {
                    SerializePropertyFromApiResult(nameof(ApiResult.Result), writer, serializer, result, apiResultType);
                }

                writer.WriteEndObject();
            }
        }

        private void SerializePropertyFromApiResult(string propertyName, JsonWriter writer, JsonSerializer serializer, ApiResult resultObjectToSerialize, Type apiResultType)
        {
            var resultPropertyToSerialize = apiResultType.GetProperty(propertyName);

            writer.WritePropertyName(ResolveUsingCamelCasing(resultPropertyToSerialize.Name));
            serializer.Serialize(writer, resultPropertyToSerialize.GetValue(resultObjectToSerialize));
        }

        private string ResolveUsingCamelCasing(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            return name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
        }
    }
}