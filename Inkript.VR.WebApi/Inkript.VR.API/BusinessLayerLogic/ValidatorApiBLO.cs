using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class ValidatorApiBLO
    {
        public ObjectResult<int> RegularRufCheck(ObjectResult<PrivateRUFResult> rufObjectResult)
        {
            ValidatorBLO biz = new ValidatorBLO();
            ApplicationBLO applicationBiz = new ApplicationBLO();
            CarUniqueNumberBLO carUniqueNumberBiz = new CarUniqueNumberBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                if (!rufObjectResult.Success)
                {
                    output.Message = string.Format("RUF Dues API failed");
                    return output;
                }

                //output.Result = biz.RegularRufCheck(applicationId, cun);

                return output;
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = String.Format("Failed to Regular RUF Check");
            }

            return output;
        }
    }
}