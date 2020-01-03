using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class RegionsApiBLO
    {
        public ObjectResult<List<Regions>> GetAllRegions()
        {
            RegionsBLO biz = new RegionsBLO();
            ObjectResult<List<Regions>> output = new ObjectResult<List<Regions>>();

            try
            {
                output.Result = biz.GetAllRegions();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Regions";
            }
            return output;
        }
    }
}