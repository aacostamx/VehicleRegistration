using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class ExemptedFeesApiBLO
    {
        public ObjectResult<List<ExemptedFees>> GetExemptedFees()
        {
            ExemptedFeesBLO biz = new ExemptedFeesBLO();
            ObjectResult<List<ExemptedFees>> output = new ObjectResult<List<ExemptedFees>>();

            try
            {
                output.Result = biz.GetExemptedFees();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Exempted Fees";
            }
            return output;
        }

        public ObjectResult<List<ExemptedFeesActive>> ReturnExemptedFees(List<int> exemptionCategoriesIds)
        {
            ExemptedFeesBLO biz = new ExemptedFeesBLO();
            ObjectResult<List<ExemptedFeesActive>> output = new ObjectResult<List<ExemptedFeesActive>>();

            try
            {
                output.Result = biz.ReturnExemptedFees(exemptionCategoriesIds);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Exempted Fees Active";
            }
            return output;
        }
    }
}