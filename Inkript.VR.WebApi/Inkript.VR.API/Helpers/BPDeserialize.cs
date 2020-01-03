using Inkript.Logging;
using Inkript.VR.Models;
using Newtonsoft.Json;
using System;

namespace Inkript.VR.API.Helpers
{
    public static class BPDeserialize
    {
        public static JsonBP DeserializeObject(string businessProcesses)
        {
            JsonBP business = new JsonBP();

            try
            {
                business = JsonConvert.DeserializeObject<JsonBP>(businessProcesses);

                if (business.PrimaryBusinessProcess != null && business.PrimaryBusinessProcess.BPId > 0)
                {
                    business.BPList.Add(business.PrimaryBusinessProcess.BPId);
                }

                if (business.SecondaryBusinessProcess != null
                    && business.SecondaryBusinessProcess.Count > 0)
                {
                    foreach (var item in business.SecondaryBusinessProcess)
                    {
                        business.BPList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                Log.Error("Invalid JSON Business Processes Object in Application Table");
            }

            return business;
        }

    }
}