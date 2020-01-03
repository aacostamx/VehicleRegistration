using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class ColorsApiBLO
    {
        public ObjectResult<List<Colors>> GetAllColors()
        {
            ColorsBLO biz = new ColorsBLO();
            ObjectResult<List<Colors>> output = new ObjectResult<List<Colors>>();

            try
            {
                output.Result = biz.GetAllColors();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get all Colors";
            }
            return output;
        }
    }
}