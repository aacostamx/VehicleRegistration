using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class CitiesApiBLO
    {
        public ObjectResult<List<Cities>> GetAllCities()
        {
            CitiesBLO biz = new CitiesBLO();
            ObjectResult<List<Cities>> output = new ObjectResult<List<Cities>>();

            try
            {
                output.Result = biz.GetAllCities();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Cities";
            }
            return output;
        }

        public ObjectResult<Cities> GetCity(int cityId)
        {
            CitiesBLO biz = new CitiesBLO();
            ObjectResult<Cities> output = new ObjectResult<Cities>();

            try
            {
                output.Result = biz.GetByCityId(cityId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Citiy " + cityId;
            }
            return output;
        }
    }
}