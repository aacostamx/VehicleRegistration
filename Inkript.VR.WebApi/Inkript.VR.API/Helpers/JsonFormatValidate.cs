using Newtonsoft.Json.Converters;

namespace Inkript.VR.API.Helpers
{
    public class JsonFormatValidate : IsoDateTimeConverter
    {
        public JsonFormatValidate(string format)
        {
            DateTimeFormat = format;
        }
    }
}