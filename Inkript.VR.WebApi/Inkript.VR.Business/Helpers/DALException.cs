using System;

namespace Inkript.VR.Business.Helpers
{
    public class DALException : Exception
    {

        public string InnerMessage { get; set; }
        public Exception ExceptionObject { get; set; }

        public DALException(string message, Exception exceptionObject)
        {
            InnerMessage = message;
            ExceptionObject = exceptionObject;
        }
    }
}
