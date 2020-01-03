using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class VehicleCategoryApiBLO
    {
        public ObjectResult<List<VehicleCategory>> GetAllVehicleCategories()
        {
            VehicleCategoryBLO biz = new VehicleCategoryBLO();
            ObjectResult<List<VehicleCategory>> output = new ObjectResult<List<VehicleCategory>>();

            try
            {
                output.Result = biz.GetAllTrims();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Vehicle Categories";
            }
            return output;
        }
    }
}