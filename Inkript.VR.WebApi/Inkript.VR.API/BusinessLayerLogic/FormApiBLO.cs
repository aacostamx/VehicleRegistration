using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class FormApiBLO
    {
        public ObjectResult<List<FORM>> GetAllForms()
        {
            FormBLO biz = new FormBLO();
            ObjectResult<List<FORM>> output = new ObjectResult<List<FORM>>();

            try
            {
                output.Result = biz.GetAllForms();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Applications";
            }
            return output;
        }
    }
}