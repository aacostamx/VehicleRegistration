using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class GovernateApiBLO
    {
        public ObjectResult<List<Governate>> GetAllGovernates()
        {
            GovernateBLO biz = new GovernateBLO();
            ObjectResult<List<Governate>> output = new ObjectResult<List<Governate>>();

            try
            {
                output.Result = biz.GetAllGovernates();
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

    }
}