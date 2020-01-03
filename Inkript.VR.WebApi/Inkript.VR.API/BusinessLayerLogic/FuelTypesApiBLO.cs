using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class FuelTypesApiBLO
    {
        public ObjectResult<List<FuelTypes>> GetAllFuelTypes()
        {
            FuelTypesBLO biz = new FuelTypesBLO();
            ObjectResult<List<FuelTypes>> output = new ObjectResult<List<FuelTypes>>();

            try
            {
                output.Result = biz.GetAllFuelTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get all Fuel Types";
            }
            return output;
        }
    }
}