using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class CarsApiBLO
    {
        public ObjectResult<GenericPagedList<Cars>> GetAllCarsPaged(int pageNumber, int pageSize)
        {
            CarsBLO biz = new CarsBLO();
            ObjectResult<GenericPagedList<Cars>> output = new ObjectResult<GenericPagedList<Cars>>();

            try
            {
                output.Result = biz.GetAllCarsPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Cars Paged";
            }
            return output;
        }
    }
}