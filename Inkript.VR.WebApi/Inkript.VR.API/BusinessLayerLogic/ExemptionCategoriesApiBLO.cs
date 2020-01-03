using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class ExemptionCategoriesApiBLO
    {
        public ObjectResult<List<ExemptionCategories>> ReturnExemptionCategories(List<int> feeIds)
        {
            ExemptionCategoriesBLO biz = new ExemptionCategoriesBLO();
            ObjectResult<List<ExemptionCategories>> output = new ObjectResult<List<ExemptionCategories>>();

            try
            {
                output.Result = biz.ReturnExemptionCategories(feeIds);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Return Exemption Categories";
            }
            return output;
        }
    }
}