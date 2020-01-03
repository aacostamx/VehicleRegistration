using System.Collections.Generic;

namespace Inkript.VR.API.Models
{
    public class ObjectResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public ObjectResult(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public ObjectResult()
        {
            Success = true;
            Message = string.Empty;
            Result = default(T);
        }
    }
}