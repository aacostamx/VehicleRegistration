using Inkript.Logging;
using Inkript.VR.API.Helpers;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class FeeCategoryApiBLO
    {
        public ObjectResult<List<FeeCategory>> GetAllFeeCategories()
        {
            FeeCategoryBLO biz = new FeeCategoryBLO();
            ObjectResult<List<FeeCategory>> output = new ObjectResult<List<FeeCategory>>();

            try
            {
                output.Result = biz.GetAllFeeCategories();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Fee Categories";
            }
            return output;
        }

        public ObjectResult<FeeCategory> GetFeecategory(int feeCategoryId)
        {
            FeeCategoryBLO biz = new FeeCategoryBLO();
            ObjectResult<FeeCategory> output = new ObjectResult<FeeCategory>();

            try
            {
                output.Result = biz.GetFeecategory(feeCategoryId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Fee Category" + feeCategoryId;
            }
            return output;
        }
    }
}