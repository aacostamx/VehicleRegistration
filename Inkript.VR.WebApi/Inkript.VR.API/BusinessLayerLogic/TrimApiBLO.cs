using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class TrimApiBLO
    {
        public ObjectResult<List<TRIM>> GetAllTrims()
        {
            TrimBLO biz = new TrimBLO();
            ObjectResult<List<TRIM>> output = new ObjectResult<List<TRIM>>();

            try
            {
                output.Result = biz.GetAllTrims();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Trims";
            }
            return output;
        }
    }
}