using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class TrunkTypeApiBLO
    {
        public ObjectResult<List<TrunkType>> GetAllTrunkTypes()
        {
            TrunkTypeBLO biz = new TrunkTypeBLO();
            ObjectResult<List<TrunkType>> output = new ObjectResult<List<TrunkType>>();

            try
            {
                output.Result = biz.GetAllTrunkTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Trunk Types";
            }
            return output;
        }
    }
}