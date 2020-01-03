using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class StatusApiBLO
    {
        public ObjectResult<List<Status>> GetAllStatus()
        {
            StatusBLO biz = new StatusBLO();
            ObjectResult<List<Status>> output = new ObjectResult<List<Status>>();

            try
            {
                output.Result = biz.GetAllStatus();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Status";
            }
            return output;
        }

        public ObjectResult<Status> GetStatus(int statusId)
        {
            StatusBLO biz = new StatusBLO();
            ObjectResult<Status> output = new ObjectResult<Status>();

            try
            {
                if (!biz.StatusExist(statusId))
                {
                    output.Message = string.Format("Status Id: '{0}' Not Found", statusId);
                    return output;
                }

                output.Result = biz.GetStatus(statusId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Status";
            }
            return output;
        }
    }
}