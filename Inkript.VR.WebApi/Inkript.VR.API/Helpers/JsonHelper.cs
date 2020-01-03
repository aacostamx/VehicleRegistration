using Inkript.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkript.VR.API.Helpers
{
    public class JsonHelper
    {
        public static bool IsValidJson(string jsonInput)
        {
            bool isValid = false;
            jsonInput = jsonInput.Trim();
            if ((jsonInput.StartsWith("{") && jsonInput.EndsWith("}"))
                || (jsonInput.StartsWith("[") && jsonInput.EndsWith("]")))
            {
                try
                {
                    JToken obj = JToken.Parse(jsonInput);
                    isValid = true;
                }
                catch (JsonReaderException jex)
                {
                    Log.Error(jex);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
            return isValid;
        }

        public static bool JsonIsNull(string json)
        {
            return string.IsNullOrEmpty(json);
        }
    }
}