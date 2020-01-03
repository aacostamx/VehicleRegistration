using Newtonsoft.Json;

namespace Inkript.VR.API.Models
{
    public class ApiResponse<T>
    {
        public string Flag { get; set; }
        public string Message { get; set; }
        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string RequestId { get; set; }

        public ApiResponse(string flag, string message, string statusCode, string statusMessage, T result, string requestId)
        {
            Flag = flag;
            Message = message;
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            Result = result;
            RequestId = requestId;
        }

        public ApiResponse()
        {
            Flag = "00";
            Message = string.Empty;
            StatusCode = string.Empty;
            StatusMessage = string.Empty;
            Result = default(T);
            RequestId = string.Empty;
        }
    }
}