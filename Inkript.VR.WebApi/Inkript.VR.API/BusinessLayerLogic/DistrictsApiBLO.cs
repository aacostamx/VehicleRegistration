using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class DistrictsApiBLO
    {
        public ObjectResult<List<Districts>> GetAllDistricts()
        {
            DistrictsBLO biz = new DistrictsBLO();
            ObjectResult<List<Districts>> output = new ObjectResult<List<Districts>>();

            try
            {
                output.Result = biz.GetAllDistricts();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Districts";
            }
            return output;
        }
    }
}