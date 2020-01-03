using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class CompanyCategoryApiBLO
    {
        public ObjectResult<List<CompanyCategory>> GetAllCompanyCategories()
        {
            CompanyCategoryBLO biz = new CompanyCategoryBLO();
            ObjectResult<List<CompanyCategory>> output = new ObjectResult<List<CompanyCategory>>();

            try
            {
                output.Result = biz.GetAllCompanyCategories();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Company Categories";
            }
            return output;
        }
    }
}