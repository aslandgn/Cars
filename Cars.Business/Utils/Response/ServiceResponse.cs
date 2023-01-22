using System.Net;
using System.Text.Json.Serialization;

namespace Cars.Business.Utils.Response
{
    public class ServiceResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExceptionMessage { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Data { get; set; }

        public static ServiceResponse<T> Ok(T data)
        {
            return new ServiceResponse<T>
            {
                Data = data,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static ServiceResponse<T> NotFound(string message)
        {
            return new ServiceResponse<T>
            {
                ExceptionMessage = message,
                StatusCode = HttpStatusCode.NotFound
            };
        }

        public static ServiceResponse<T> BadRequest(string message)
        {
            return new ServiceResponse<T>
            {
                ExceptionMessage = message,
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }

    public class ServiceResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExceptionMessage { get; set; }

        public ServiceResponse Ok()
        {
            StatusCode = HttpStatusCode.OK;
            return this;
        }

        public ServiceResponse NotFound(string message)
        {
            ExceptionMessage = message;
            StatusCode = HttpStatusCode.NotFound;
            return this;
        }

        public ServiceResponse BadRequest(string message)
        {
            ExceptionMessage = message;
            StatusCode = HttpStatusCode.BadRequest;
            return this;
        }
    }
}
