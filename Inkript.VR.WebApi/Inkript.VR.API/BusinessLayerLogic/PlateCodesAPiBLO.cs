using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class PlateCodesAPiBLO
    {
        public ObjectResult<List<PlateCodes>> GetAllPlateCodes()
        {
            PlateCodesBLO biz = new PlateCodesBLO();
            ObjectResult<List<PlateCodes>> output = new ObjectResult<List<PlateCodes>>();

            try
            {
                output.Result = biz.GetAllPlateCodes();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Plate Codes";
            }
            return output;
        }
    }
}