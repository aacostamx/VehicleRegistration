using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class AppConfigCommitApiBLO
    {
        public ObjectResult<List<AppConfigCommit>> GetAllAppConfigCommit()
        {
            AppConfigCommitBLO biz = new AppConfigCommitBLO();
            ObjectResult<List<AppConfigCommit>> output = new ObjectResult<List<AppConfigCommit>>();

            try
            {
                output.Result = biz.GetAllAppConfigCommit();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All AppConfigCommit";
            }
            return output;
        }
    }
}